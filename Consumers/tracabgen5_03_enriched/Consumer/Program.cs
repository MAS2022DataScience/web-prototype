using System;
using System.Threading;
using System.Data.SqlClient;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using com.mas2022datascience.avro.v1;
using System.ComponentModel.DataAnnotations;
using Confluent.SchemaRegistry.Serdes;
using Confluent.Kafka.SyncOverAsync;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Globalization;

namespace Consumer
{
    class Program
    {
        const string brokerList = "localhost:9092,localhost:9093";
        const string groupId = "KafkaConsumer_NET";

        static void Main(string[] args)
        {
            string topicName = "tracabgen5_03_enriched";
            //Topic name aus Argumentsliste übernehmen
            if (args.Length > 0)
            {
                topicName = args[0];
            }
            Console.WriteLine("Listen to Kafka topic: " + topicName);
            runConsumer(10, topicName);
        }

        static void runConsumer(int waitMsInBetween, string strTopicName)
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = brokerList,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
                AutoCommitIntervalMs = 2000
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = "localhost:8081"
            };
            bool cancelled = false;
            //bool bDataOk = false;

            using (var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))
            {
                using (var consumer = new ConsumerBuilder<string, TracabGen5TF01>(consumerConfig)
                    //.SetKeyDeserializer(new AvroDeserializer<string>(schemaRegistry).AsSyncOverAsync())
                    .SetValueDeserializer(new AvroDeserializer<TracabGen5TF01>(schemaRegistry).AsSyncOverAsync())
                    .Build())
                {
                    consumer.Subscribe(strTopicName);
                    var cancelToken = new CancellationTokenSource();

                    String strDbConn = @"server=localhost;uid=<user>;pwd=<password>;database=FootballMAS22";
                    using (SqlConnection connection = new SqlConnection(strDbConn))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = connection;
                        connection.Open();

                        while (!cancelled)
                        {
                            try
                            {
                                var consumeResult = consumer.Consume(cancelToken.Token);
                                //var consumeResult = consumer.Consume();
                                var oData = consumeResult.Message.Value;
                                string json = JsonConvert.SerializeObject(oData);
                                string strObjects = JsonConvert.SerializeObject(oData.objects);

                                //Console.WriteLine($"consumed Key: {consumeResult.Key}; Value {consumeResult.Value}");
                                //Console.WriteLine($"utc -> {oData.utc} | isBallInPlay -> {oData.isBallInPlay} | ballPossession -> {oData.isBallInPlay}");
                                Console.WriteLine($"utc:{oData.utc}");
                                //Console.WriteLine($"{strObjects}");


                                //Prepare data and write to Database
                                DateTime dtUtc = DateTime.ParseExact(oData.utc, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
                                long ts = new DateTimeOffset(dtUtc).ToUnixTimeMilliseconds();

                                cmd.CommandText = $"insert t_tracabgen5_03_enriched (matchId,ts,utc,isBallInPlay,ballPossession,contactDevInfo,json) values({oData.matchId},{ts},convert(datetime,'{oData.utc}',127),'{oData.isBallInPlay}','{oData.ballPossession}','{oData.contactDevInfo}','{JsonConvert.SerializeObject(oData)}')"; ;
                                cmd.ExecuteNonQuery();


                                //cancelled = true;
                                //Console.WriteLine($"Consumer Record:(Key: {consumeResult.Message.Key}, Value: {consumeResult.Message.Value} Partition: {consumeResult.TopicPartition.Partition} Offset: {consumeResult.TopicPartitionOffset.Offset}");
                            }
                            catch (ConsumeException e)
                            {
                                Console.WriteLine($"consume error: {e.Error.Reason} ### {e.InnerException}");
                            }
                            // handle message
                            Thread.Sleep(waitMsInBetween);
                        }
                        consumer.Close();
                        connection.Close();
                    }
                }
            }
        }
    }
}
