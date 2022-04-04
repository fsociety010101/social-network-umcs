CREATE DATABASE  IF NOT EXISTS `social-network` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_polish_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `social-network`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: social-network
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `blocked users`
--

DROP TABLE IF EXISTS `blocked users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `blocked users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BlockingUserID` int NOT NULL,
  `BlockedUserID` int NOT NULL,
  `BlockedDate` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ID constraint` (`BlockingUserID`,`BlockedUserID`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `User1ID_idx` (`BlockingUserID`) /*!80000 INVISIBLE */,
  KEY `User2ID_idx` (`BlockedUserID`),
  CONSTRAINT `User1ID0` FOREIGN KEY (`BlockingUserID`) REFERENCES `users` (`UserID`),
  CONSTRAINT `User2ID0` FOREIGN KEY (`BlockedUserID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blocked users`
--

LOCK TABLES `blocked users` WRITE;
/*!40000 ALTER TABLE `blocked users` DISABLE KEYS */;
/*!40000 ALTER TABLE `blocked users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comment votes`
--

DROP TABLE IF EXISTS `comment votes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comment votes` (
  `CommentVoteID` int NOT NULL,
  `CommentID` int NOT NULL,
  `VotingUserID` int NOT NULL,
  `IsUp` tinyint DEFAULT NULL,
  PRIMARY KEY (`CommentVoteID`),
  UNIQUE KEY `CommentVoteID_UNIQUE` (`CommentVoteID`),
  KEY `fk_comment votes_users1_idx` (`VotingUserID`),
  KEY `fk_comment votes_comments1` (`CommentID`),
  CONSTRAINT `fk_comment votes_comments1` FOREIGN KEY (`CommentID`) REFERENCES `comments` (`CommentID`),
  CONSTRAINT `fk_comment votes_users1` FOREIGN KEY (`VotingUserID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comment votes`
--

LOCK TABLES `comment votes` WRITE;
/*!40000 ALTER TABLE `comment votes` DISABLE KEYS */;
/*!40000 ALTER TABLE `comment votes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comments`
--

DROP TABLE IF EXISTS `comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comments` (
  `CommentID` int NOT NULL,
  `SenderID` int NOT NULL,
  `PostID` int NOT NULL,
  `Content` mediumtext,
  `DateTime` datetime NOT NULL,
  `WasRemoved` tinyint DEFAULT NULL,
  PRIMARY KEY (`CommentID`),
  UNIQUE KEY `CommentID_UNIQUE` (`CommentID`),
  KEY `fk_comments_users1_idx` (`SenderID`),
  KEY `fk_comments_posts1_idx` (`PostID`),
  CONSTRAINT `fk_comments_posts1` FOREIGN KEY (`PostID`) REFERENCES `posts` (`PostID`),
  CONSTRAINT `fk_comments_users1` FOREIGN KEY (`SenderID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comments`
--

LOCK TABLES `comments` WRITE;
/*!40000 ALTER TABLE `comments` DISABLE KEYS */;
/*!40000 ALTER TABLE `comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `friends`
--

DROP TABLE IF EXISTS `friends`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `friends` (
  `User1ID` int NOT NULL,
  `User2ID` int NOT NULL,
  `FriendshipStartDate` date DEFAULT NULL,
  UNIQUE KEY `ID constraint` (`User1ID`,`User2ID`),
  KEY `User1ID_idx` (`User1ID`) /*!80000 INVISIBLE */,
  KEY `User2ID_idx` (`User2ID`),
  CONSTRAINT `User1ID` FOREIGN KEY (`User1ID`) REFERENCES `users` (`UserID`),
  CONSTRAINT `User2ID` FOREIGN KEY (`User2ID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `friends`
--

LOCK TABLES `friends` WRITE;
/*!40000 ALTER TABLE `friends` DISABLE KEYS */;
/*!40000 ALTER TABLE `friends` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group`
--

DROP TABLE IF EXISTS `group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group` (
  `GroupID` int NOT NULL,
  `CreatorID` int NOT NULL,
  `Name` varchar(20) NOT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `IsClosed` tinyint DEFAULT NULL,
  `ConversationID` int DEFAULT NULL,
  PRIMARY KEY (`GroupID`),
  KEY `fk_group_users1_idx` (`CreatorID`),
  CONSTRAINT `fk_group_users1` FOREIGN KEY (`CreatorID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group`
--

LOCK TABLES `group` WRITE;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
/*!40000 ALTER TABLE `group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group participant`
--

DROP TABLE IF EXISTS `group participant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group participant` (
  `GroupID` int NOT NULL,
  `UserID` int NOT NULL,
  `IsAdmin` tinyint DEFAULT NULL,
  `Nick` varchar(20) DEFAULT NULL,
  UNIQUE KEY `ID constraint` (`UserID`,`GroupID`),
  KEY `fk_group participant_users1_idx` (`UserID`),
  KEY `fk_group participant_group1` (`GroupID`),
  CONSTRAINT `fk_group participant_group1` FOREIGN KEY (`GroupID`) REFERENCES `group` (`GroupID`),
  CONSTRAINT `fk_group participant_users1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group participant`
--

LOCK TABLES `group participant` WRITE;
/*!40000 ALTER TABLE `group participant` DISABLE KEYS */;
/*!40000 ALTER TABLE `group participant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invites`
--

DROP TABLE IF EXISTS `invites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invites` (
  `InvitingUserID` int NOT NULL,
  `InvitedUserID` int NOT NULL,
  `InviteDate` date DEFAULT NULL,
  UNIQUE KEY `ID constraint` (`InvitingUserID`,`InvitedUserID`),
  KEY `User1ID_idx` (`InvitingUserID`) /*!80000 INVISIBLE */,
  KEY `User2ID_idx` (`InvitedUserID`),
  CONSTRAINT `User1ID00` FOREIGN KEY (`InvitingUserID`) REFERENCES `users` (`UserID`),
  CONSTRAINT `User2ID00` FOREIGN KEY (`InvitedUserID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invites`
--

LOCK TABLES `invites` WRITE;
/*!40000 ALTER TABLE `invites` DISABLE KEYS */;
/*!40000 ALTER TABLE `invites` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `messages`
--

DROP TABLE IF EXISTS `messages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `messages` (
  `MessageID` int NOT NULL,
  `ConversationID` int NOT NULL,
  `ConversationParticipantID` int NOT NULL,
  `WasRemoved` tinyint DEFAULT NULL,
  `DateTime` datetime NOT NULL,
  `Content` mediumtext,
  `WasEdited` tinyint DEFAULT NULL,
  `LastEditTime` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`MessageID`),
  UNIQUE KEY `DateTime_UNIQUE` (`DateTime`),
  KEY `fk_messages_conversations1_idx` (`ConversationID`),
  KEY `fk_messages_conversation participant1_idx` (`ConversationParticipantID`),
  CONSTRAINT `fk_messages_conversation participant1` FOREIGN KEY (`ConversationParticipantID`) REFERENCES `mydb`.`conversation participant` (`ConversationID`),
  CONSTRAINT `fk_messages_conversations1` FOREIGN KEY (`ConversationID`) REFERENCES `mydb`.`conversations` (`ConversationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `messages`
--

LOCK TABLES `messages` WRITE;
/*!40000 ALTER TABLE `messages` DISABLE KEYS */;
/*!40000 ALTER TABLE `messages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `post view`
--

DROP TABLE IF EXISTS `post view`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `post view` (
  `PostViewID` int NOT NULL,
  `PostID` int NOT NULL,
  `UserID` int NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`PostViewID`),
  UNIQUE KEY `PostViewID_UNIQUE` (`PostViewID`),
  KEY `fk_senderid_idx` (`UserID`),
  KEY `fk_post view_posts1` (`PostID`),
  CONSTRAINT `fk_post view_posts1` FOREIGN KEY (`PostID`) REFERENCES `posts` (`PostID`),
  CONSTRAINT `fk_senderid` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `post view`
--

LOCK TABLES `post view` WRITE;
/*!40000 ALTER TABLE `post view` DISABLE KEYS */;
/*!40000 ALTER TABLE `post view` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `post votes`
--

DROP TABLE IF EXISTS `post votes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `post votes` (
  `PostVoteID` int NOT NULL,
  `PostID` int NOT NULL,
  `VotingUserID` int NOT NULL,
  `IsUp` tinyint DEFAULT NULL,
  PRIMARY KEY (`PostVoteID`),
  KEY `fk_post votes_users1_idx` (`VotingUserID`),
  KEY `fk_post votes_posts1` (`PostID`),
  CONSTRAINT `fk_post votes_posts1` FOREIGN KEY (`PostID`) REFERENCES `posts` (`PostID`),
  CONSTRAINT `fk_post votes_users1` FOREIGN KEY (`VotingUserID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `post votes`
--

LOCK TABLES `post votes` WRITE;
/*!40000 ALTER TABLE `post votes` DISABLE KEYS */;
/*!40000 ALTER TABLE `post votes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `posts`
--

DROP TABLE IF EXISTS `posts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `posts` (
  `PostID` int NOT NULL,
  `SenderID` int NOT NULL,
  `GroupID` int NOT NULL,
  `ProfileID` int NOT NULL,
  `Content` mediumtext,
  `DataTime` datetime NOT NULL,
  `messagescol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PostID`),
  KEY `fk_posts_users_idx` (`SenderID`),
  KEY `fk_posts_group1_idx` (`GroupID`),
  CONSTRAINT `fk_posts_group1` FOREIGN KEY (`GroupID`) REFERENCES `group` (`GroupID`),
  CONSTRAINT `fk_posts_users` FOREIGN KEY (`SenderID`) REFERENCES `users` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `posts`
--

LOCK TABLES `posts` WRITE;
/*!40000 ALTER TABLE `posts` DISABLE KEYS */;
/*!40000 ALTER TABLE `posts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `Surname` varchar(20) NOT NULL,
  `PasswordHash` varchar(50) NOT NULL,
  `EmailAddress` varchar(35) NOT NULL,
  `TelephoneNumber` varchar(15) DEFAULT NULL,
  `JoinDate` date NOT NULL,
  `BirthdayDate` date NOT NULL,
  `AllowInvites` tinyint DEFAULT '1',
  `WorkingPlace` varchar(45) DEFAULT NULL,
  `LearningPlace` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `EmailAddress_UNIQUE` (`EmailAddress`),
  UNIQUE KEY `UserID_UNIQUE` (`UserID`),
  UNIQUE KEY `TelephoneNumber_UNIQUE` (`TelephoneNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Adam','Kowalski','nie ma hasha jescze','adam.kowalski@o2.pl','124213122','2012-12-12','2000-12-12',0,'no','no'),(4,'Marek','Kowalski','nie ma hasha jescze','marek.kowalski@o2.pl','35436345','2012-12-12','2000-12-12',0,'no','no'),(5,'Jan','Kowalski','nie ma hasha jescze','jan.kowalski@o2.pl','356435345','2012-12-12','2000-12-12',0,'no','no'),(8,'Pawel','Kowalski','nie ma hasha jescze','pawel.kowalski@o2.pl','4124214213','2012-12-12','2000-12-12',0,'no','no');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-03 11:00:04
