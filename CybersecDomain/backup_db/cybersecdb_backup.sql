-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: cybersecdb
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `cybersecdb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `cybersecdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `cybersecdb`;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20250810220714_Initial','8.0.7');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alternative_title`
--

DROP TABLE IF EXISTS `alternative_title`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alternative_title` (
  `AlternativeTitleId` int unsigned NOT NULL AUTO_INCREMENT,
  `AltTitle` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProfileId` int unsigned NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`AlternativeTitleId`),
  KEY `IX_Alternative_Title_ProfileId` (`ProfileId`),
  CONSTRAINT `FK_Alternative_Title_Profiles_ProfileId` FOREIGN KEY (`ProfileId`) REFERENCES `profiles` (`profile_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alternative_title`
--

LOCK TABLES `alternative_title` WRITE;
/*!40000 ALTER TABLE `alternative_title` DISABLE KEYS */;
INSERT INTO `alternative_title` VALUES (1,'Cybersecurity Programme Director',4,'2025-08-11 21:04:18.000000'),(2,'Information Security Officer (ISO)',4,'2025-08-11 21:04:18.000000'),(3,'Information Security Manager',4,'2025-08-11 21:04:18.000000'),(4,'Head of Information Security',4,'2025-08-11 21:04:18.000000'),(5,'IT/ICT Security Officer',4,'2025-08-11 21:04:18.000000'),(6,'Pentester',5,'2025-08-11 21:04:18.000000'),(7,'Ethical Hacker',5,'2025-08-11 21:04:18.000000'),(8,'Vulnerability Analyst',5,'2025-08-11 21:04:18.000000'),(9,'Cybersecurity Tester',5,'2025-08-11 21:04:18.000000'),(10,'Offensive Cybersecurity Expert',5,'2025-08-11 21:04:18.000000'),(11,'Defensive Cybersecurity Expert',5,'2025-08-11 21:04:19.000000'),(12,'Red Team Expert',5,'2025-08-11 21:04:19.000000'),(13,'Red Teamer',5,'2025-08-11 21:04:19.000000'),(14,'Cybersecurity Solutions Architect',6,'2025-08-11 21:04:19.000000'),(15,'Cybersecurity Designer',6,'2025-08-11 21:04:19.000000'),(16,'Data Security Architect',6,'2025-08-11 21:04:19.000000'),(19,'atatht',8,'2025-08-19 14:25:23.051516'),(20,'atatht',9,'2025-08-19 14:26:09.262321'),(21,'atin',10,'2025-08-19 18:16:07.334460'),(22,'atin',11,'2025-08-19 18:16:14.656393'),(23,'atin',12,'2025-08-19 18:18:48.469489'),(24,'',13,'2025-08-19 18:21:15.355134'),(25,'alotooo',14,'2025-08-19 18:23:15.203331'),(26,'',15,'2025-08-19 18:24:38.427314'),(27,'',16,'2025-08-19 18:25:36.667884'),(30,'atatht',7,'2025-08-19 19:32:16.824182'),(34,'atatht',1,'2025-08-19 19:43:37.423046'),(35,'atatht',17,'2025-08-19 20:28:28.104039');
/*!40000 ALTER TABLE `alternative_title` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deliverable`
--

DROP TABLE IF EXISTS `deliverable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `deliverable` (
  `DeliverableId` int unsigned NOT NULL AUTO_INCREMENT,
  `DeliverableName` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProfileId` int unsigned NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`DeliverableId`),
  KEY `IX_Deliverable_ProfileId` (`ProfileId`),
  CONSTRAINT `FK_Deliverable_Profiles_ProfileId` FOREIGN KEY (`ProfileId`) REFERENCES `profiles` (`profile_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deliverable`
--

LOCK TABLES `deliverable` WRITE;
/*!40000 ALTER TABLE `deliverable` DISABLE KEYS */;
INSERT INTO `deliverable` VALUES (1,'Cybersecurity Strategy',4,'2025-08-11 21:04:19.000000'),(2,'Cybersecurity Policy',4,'2025-08-11 21:04:19.000000'),(3,'Vulnerability Assessment Results Report',5,'2025-08-11 21:04:19.000000'),(4,'Penetration Testing Report',5,'2025-08-11 21:04:19.000000'),(5,'Cybersecurity Architecture Diagram',6,'2025-08-11 21:04:19.000000'),(6,'Cybersecurity Requirements Report',6,'2025-08-11 21:04:19.000000'),(9,'string',8,'2025-08-19 14:25:23.061356'),(10,'string',9,'2025-08-19 14:26:09.273253'),(11,'code folie',10,'2025-08-19 18:16:07.353046'),(12,'code folie',11,'2025-08-19 18:16:14.664745'),(13,'code folie',12,'2025-08-19 18:18:48.477229'),(14,'deverylll',14,'2025-08-19 18:23:15.212796'),(17,'RRRRR',7,'2025-08-19 19:32:17.089411'),(21,'RRRRR',1,'2025-08-19 19:43:37.438160'),(22,'RRRRR',17,'2025-08-19 20:28:28.117777');
/*!40000 ALTER TABLE `deliverable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `keyskills`
--

DROP TABLE IF EXISTS `keyskills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `keyskills` (
  `KeySkillId` int unsigned NOT NULL AUTO_INCREMENT,
  `Skill` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProfileId` int unsigned NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`KeySkillId`),
  KEY `IX_KeySkills_ProfileId` (`ProfileId`),
  CONSTRAINT `FK_KeySkills_Profiles_ProfileId` FOREIGN KEY (`ProfileId`) REFERENCES `profiles` (`profile_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `keyskills`
--

LOCK TABLES `keyskills` WRITE;
/*!40000 ALTER TABLE `keyskills` DISABLE KEYS */;
INSERT INTO `keyskills` VALUES (1,'Assess and enhance an organisation\'s cybersecurity posture',4,'2025-08-11 21:04:19.000000'),(2,'Analyse and implement cybersecurity policies, certifications, standards, methodologies and frameworks',4,'2025-08-11 21:04:19.000000'),(3,'Develop, champion and lead the execution of a cybersecurity strategy',4,'2025-08-11 21:04:19.000000'),(4,'Influence an organisation\'s cybersecurity culture',4,'2025-08-11 21:04:19.000000'),(5,'Develop codes, scripts and programmes',5,'2025-08-11 21:04:19.000000'),(6,'Perform social engineering',5,'2025-08-11 21:04:19.000000'),(7,'Identify and exploit vulnerabilities',5,'2025-08-11 21:04:19.000000'),(8,'Conduct ethical hacking',5,'2025-08-11 21:04:19.000000'),(9,'Think creatively and outside the box',5,'2025-08-11 21:04:19.000000'),(10,'Conduct user and business security requirements analysis',6,'2025-08-11 21:04:19.000000'),(11,'Draw cybersecurity architectural and functional specifications',6,'2025-08-11 21:04:19.000000'),(12,'Design systems and architectures based on security and privacy by design principles',6,'2025-08-11 21:04:19.000000'),(13,'Guide and communicate with implementers and IT/OT personnel',6,'2025-08-11 21:04:19.000000'),(16,'string',8,'2025-08-19 14:25:23.081581'),(17,'string',9,'2025-08-19 14:26:09.293322'),(18,'cybeeert',10,'2025-08-19 18:16:07.380443'),(19,'cybeeert',11,'2025-08-19 18:16:14.682568'),(20,'cybeeert',12,'2025-08-19 18:18:48.494876'),(21,'skillmmaker',14,'2025-08-19 18:23:15.233755'),(24,'string',7,'2025-08-19 19:32:17.188087'),(28,'string',1,'2025-08-19 19:43:37.470521'),(29,'string',17,'2025-08-19 20:28:28.143707');
/*!40000 ALTER TABLE `keyskills` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `knowledge`
--

DROP TABLE IF EXISTS `knowledge`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `knowledge` (
  `KnowledgeId` int unsigned NOT NULL AUTO_INCREMENT,
  `KnowledgeName` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProfileId` int unsigned NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`KnowledgeId`),
  KEY `IX_Knowledge_ProfileId` (`ProfileId`),
  CONSTRAINT `FK_Knowledge_Profiles_ProfileId` FOREIGN KEY (`ProfileId`) REFERENCES `profiles` (`profile_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `knowledge`
--

LOCK TABLES `knowledge` WRITE;
/*!40000 ALTER TABLE `knowledge` DISABLE KEYS */;
INSERT INTO `knowledge` VALUES (1,'Cybersecurity policies',4,'2025-08-11 21:04:19.000000'),(2,'Cybersecurity standards, methodologies and frameworks',4,'2025-08-11 21:04:19.000000'),(3,'Cybersecurity recommendations and best practices',4,'2025-08-11 21:04:19.000000'),(4,'Cybersecurity related laws, regulations and legislations',4,'2025-08-11 21:04:19.000000'),(5,'Cybersecurity attack procedures',5,'2025-08-11 21:04:19.000000'),(6,'Information technology (IT) and operational technology (OT) appliances',5,'2025-08-11 21:04:19.000000'),(7,'Offensive and defensive security procedures',5,'2025-08-11 21:04:19.000000'),(8,'Penetration testing procedures',5,'2025-08-11 21:04:19.000000'),(9,'Cybersecurity-related certifications',6,'2025-08-11 21:04:19.000000'),(10,'Cybersecurity recommendations and best practices',6,'2025-08-11 21:04:19.000000'),(11,'Security architecture reference models',6,'2025-08-11 21:04:19.000000'),(12,'Cybersecurity-related technologies',6,'2025-08-11 21:04:19.000000'),(15,'string',8,'2025-08-19 14:25:23.070705'),(16,'string',9,'2025-08-19 14:26:09.284421'),(17,'rrrunnn',10,'2025-08-19 18:16:07.368121'),(18,'rrrunnn',11,'2025-08-19 18:16:14.673027'),(19,'rrrunnn',12,'2025-08-19 18:18:48.487012'),(20,'nonwww',14,'2025-08-19 18:23:15.223347'),(23,'string',7,'2025-08-19 19:32:17.142676'),(27,'string',1,'2025-08-19 19:43:37.456158'),(28,'string',17,'2025-08-19 20:28:28.132805');
/*!40000 ALTER TABLE `knowledge` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logos`
--

DROP TABLE IF EXISTS `logos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logos` (
  `LogoId` int unsigned NOT NULL AUTO_INCREMENT,
  `Url` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`LogoId`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logos`
--

LOCK TABLES `logos` WRITE;
/*!40000 ALTER TABLE `logos` DISABLE KEYS */;
INSERT INTO `logos` VALUES (1,'/images/cyber-logo.png','2025-08-11 21:04:18.000000','2025-08-11 21:04:18.000000'),(4,'string','2025-08-19 14:25:23.008287','0001-01-01 00:00:00.000000'),(5,'string','2025-08-19 14:26:09.240666','0001-01-01 00:00:00.000000'),(6,'','2025-08-19 18:16:07.297867','0001-01-01 00:00:00.000000'),(7,'','2025-08-19 18:16:14.636433','0001-01-01 00:00:00.000000'),(8,'','2025-08-19 18:18:48.449824','0001-01-01 00:00:00.000000'),(9,'','2025-08-19 18:21:15.326048','0001-01-01 00:00:00.000000'),(10,'Test01','2025-08-19 18:23:15.182287','0001-01-01 00:00:00.000000'),(11,'','2025-08-19 18:24:38.390308','0001-01-01 00:00:00.000000'),(12,'uuuuuu','2025-08-19 18:25:36.646665','0001-01-01 00:00:00.000000'),(14,'string','2025-08-19 18:54:14.221234','0001-01-01 00:00:00.000000'),(15,'string','2025-08-19 19:32:16.110496','0001-01-01 00:00:00.000000'),(16,'string','2025-08-19 19:34:25.307491','0001-01-01 00:00:00.000000'),(19,'string','2025-08-19 19:43:37.389292','0001-01-01 00:00:00.000000'),(20,'string','2025-08-19 20:28:28.079388','0001-01-01 00:00:00.000000');
/*!40000 ALTER TABLE `logos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `main_task`
--

DROP TABLE IF EXISTS `main_task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `main_task` (
  `MainTaskId` int unsigned NOT NULL AUTO_INCREMENT,
  `Task` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProfileId` int unsigned NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`MainTaskId`),
  KEY `IX_Main_task_ProfileId` (`ProfileId`),
  CONSTRAINT `FK_Main_task_Profiles_ProfileId` FOREIGN KEY (`ProfileId`) REFERENCES `profiles` (`profile_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `main_task`
--

LOCK TABLES `main_task` WRITE;
/*!40000 ALTER TABLE `main_task` DISABLE KEYS */;
INSERT INTO `main_task` VALUES (1,'Define, implement, communicate and maintain cybersecurity goals, requirements, strategies, policies',4,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(2,'Prepare and present cybersecurity vision, strategies and policies for approval by senior management',4,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(3,'Supervise the application and improvement of the Information Security Management System (ISMS)',4,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(4,'Identify, analyse and assess technical and organisational cybersecurity vulnerabilities',5,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(5,'Identify attack vectors, uncover and demonstrate exploitation of technical cybersecurity vulnerabilities',5,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(6,'Test systems and operations compliance with regulatory standards',5,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(7,'Design and propose a secure architecture to implement the organisation\'s strategy',6,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(8,'Develop organisation\'s cybersecurity architecture to address security and privacy requirements',6,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(9,'Produce architectural documentation and specifications',6,'2025-08-11 21:04:19.000000','2025-08-11 21:04:19.000000'),(12,'string',8,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(13,'string',9,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(14,'tacko',10,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(15,'tacko',11,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(16,'tacko',12,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(17,'plannings',14,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(20,'string',7,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(24,'string',1,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(25,'string',17,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000');
/*!40000 ALTER TABLE `main_task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profiles`
--

DROP TABLE IF EXISTS `profiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profiles` (
  `profile_id` int unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `shortname` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SummaryStatement` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Mission` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `LogoId` int unsigned DEFAULT NULL,
  PRIMARY KEY (`profile_id`),
  KEY `IX_Profiles_LogoId` (`LogoId`),
  CONSTRAINT `FK_Profiles_Logos_LogoId` FOREIGN KEY (`LogoId`) REFERENCES `logos` (`LogoId`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profiles`
--

LOCK TABLES `profiles` WRITE;
/*!40000 ALTER TABLE `profiles` DISABLE KEYS */;
INSERT INTO `profiles` VALUES (1,'escf','tttttt','string','sss','2025-08-11 21:04:18.000000','2025-08-11 21:04:18.000000',0,19),(2,'Cyber Threat Intelligence Specialist','ctis','Collect, process, analyse data and information to produce actionable intelligence reports and disseminate them to target stakeholders.',NULL,'2025-08-11 21:04:18.000000','2025-08-11 21:04:18.000000',0,1),(3,'Cybersecurity Implementer','cim','Develop, deploy and operate cybersecurity solutions (systems, assets, software, controls and services) on infrastructures and products.',NULL,'2025-08-11 21:04:18.000000','2025-08-11 21:04:18.000000',1,1),(4,'Chief Information Security Officer','ciso','Manages an organisation\'s cybersecurity strategy and its implementation to ensure that digital systems, services and assets are adequately secure and protected.','Defines, maintains and communicates the cybersecurity vision, strategy, policies and procedures. Manages the implementation of the cybersecurity policy across the organisation. Assures information exchange with external authorities and professional bodies.','2025-08-11 21:04:18.000000','2025-08-11 21:04:18.000000',1,1),(5,'Penetration Tester','pte','Assess the effectiveness of security controls, reveals and utilise cybersecurity vulnerabilities, assessing their criticality if exploited by threat actors.','Plans, designs, implements and executes penetration testing activities and attack scenarios to evaluate the effectiveness of deployed or planned security measures. Identifies vulnerabilities or failures on technical and organisational controls that affect the confidentiality, integrity and availability of ICT products (e.g. systems, hardware, software and services).','2025-08-11 21:04:18.000000','2025-08-11 21:04:18.000000',1,1),(6,'Cybersecurity Architect','car','Plans and designs security-by-design solutions (infrastructures, systems, assets, software, hardware and services) and cybersecurity controls.','Designs solutions based on security-by-design and privacy-by-design principles. Creates and continuously improves architectural models and develops appropriate architectural documentation and specifications. Coordinate secure development, integration and maintenance of cybersecurity components in line with standards and other related requirements.','2025-08-11 21:04:18.000000','2025-08-11 21:04:18.000000',1,1),(7,'escf','tttttt','string','sss','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',1,15),(8,'escf','ddddd','string','miiiiisss','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',1,4),(9,'escf','ddddd','string','miiiiisss','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',1,5),(10,'gggtr','crttt','ggtfff','malt','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',1,6),(11,'gggtr','crttt','ggtfff','malt','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',1,7),(12,'gggtr','crttt','ggtfff','malt','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',1,8),(13,'','','','','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',0,9),(14,'','','rules the teams','missiooooo','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',0,10),(15,'dfxfghh','','','','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',0,11),(16,'dfxfghh','rrrrrrr','','nnnnnn','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',1,12),(17,'escf','tttttt','string','sss','0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',1,20);
/*!40000 ALTER TABLE `profiles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-31 19:08:43
