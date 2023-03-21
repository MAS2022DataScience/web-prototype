-- Script File zur Vorbereitung der Kafka Objekte; Topics, Tables, Streams
-- Ausführen des Scripts via kSQLDB-CLI
-- docker exec -it ksqldb-cli ksql http://ksqldb-server-1:8088

-- Script ausführen; Script muss in das Verzeichnis /data-transfer kopiert werden, damit es im Docker-Container in ksql verfügbar ist
-- RUN SCRIPT '/data-transfer/<scriptname>.sql'

------------------------------------------------

-- Sollten beim ausführen des Scripts Fehler auftreten beim löschen der Tabellen und Topics (drop table) weil noch Queries am laufen sind, ist wie folgt vorzugehen
-- Queries abfragen: SHOW QUERIES;
-- Query beenden:    TERMINATE <query name>;

-- ---------------------------------------------
-- Development options
-- Set 'auto.offset.reset' = 'earliest';
-- unset 'auto.offset.reset';
-- ---------------------------------------------
-- MAS22 ---

-- ###############################################################################################

-- Set 'ksql.suppress.enabled' = 'true';

--#####################################

-- Spieler lesen

describe sTeamPlayers;
print general_match_player;
DROP STREAM IF EXISTS sTeamPlayers;

CREATE Stream sTeamPlayers  
WITH 
(kafka_topic='general_match_player', 
PARTITIONS=3,
REPLICAS=2, 
VALUE_FORMAT='AVRO');

--select * from sTeamPlayers;



--Teams lesen
DROP STREAM IF EXISTS sTeams;

CREATE Stream sTeams  
WITH 
(kafka_topic='general_match_team', 
PARTITIONS=3,
REPLICAS=2, 
VALUE_FORMAT='AVRO');

--select * from sTeams;

-- Spielfeld / Matchinfo
DROP STREAM IF EXISTS sMatchs;

CREATE Stream sMatchs  
WITH 
(kafka_topic='general_match', 
PARTITIONS=3,
REPLICAS=2, 
VALUE_FORMAT='AVRO');

--select * from sMatchs;


-- Matchphasen (Halbzeiten)
DROP STREAM IF EXISTS sMatchPhases;

CREATE Stream sMatchPhases  
WITH 
(kafka_topic='general_match_phase', 
PARTITIONS=3,
REPLICAS=2, 
VALUE_FORMAT='AVRO');

--select * from sMatchPhases;

-- Spielerbeschleunigung
DROP STREAM IF EXISTS sGeneral_03_acceleration;

CREATE Stream sGeneral_03_acceleration  
WITH 
(kafka_topic='general_03_acceleration', 
PARTITIONS=3,
REPLICAS=2, 
VALUE_FORMAT='AVRO');

--select * from sGeneral_03_acceleration;
--select playerid, type, count(*) from sGeneral_03_acceleration group by playerid, type;

-- Transition DEF/OFF
DROP STREAM IF EXISTS sGeneral_04_ball_possession_change;

CREATE Stream sGeneral_04_ball_possession_change 
WITH 
(kafka_topic='general_04_ball_possession_change', 
PARTITIONS=3,
REPLICAS=2, 
VALUE_FORMAT='AVRO');


--select * from  sGeneral_04_ball_possession_change;

-- Manuelle Events
DROP STREAM IF EXISTS sManualEvents;

CREATE Stream sManualEvents (
  name varchar,
  position varchar,
  dauer varchar,
  action varchar,
  comment varchar,
  evaluation varchar,
  wo varchar,
  zeitabschnitt varchar,
  zone varchar,
  timestamp varchar,
  matchid varchar
) 
WITH 
(kafka_topic='manualEvents', 
PARTITIONS=3,
REPLICAS=2, 
VALUE_FORMAT='JSON');

--select * from sManualEvents;












-- Spieler lesen
sTeamPlayers;

--Teams lesen
sTeams  

-- Spielfeld / Matchinfo
sMatchs

-- Matchphasen (Halbzeiten)
sMatchPhases


-- Spielerbeschleunigung
sGeneral_03_acceleration

-- Transition DEF/OFF
sGeneral_04_ball_possession_change


-- Manuelle Events
sManualEvents
