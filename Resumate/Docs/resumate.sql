-- phpMyAdmin SQL Dump
-- version 3.3.9.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Sep 27, 2012 at 11:51 PM
-- Server version: 5.5.9
-- PHP Version: 5.3.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `resumate`
--

-- --------------------------------------------------------

--
-- Table structure for table `element_awards`
--

CREATE TABLE `element_awards` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resumeID` int(11) NOT NULL,
  `title` text NOT NULL,
  `description` text NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `element_awards`
--


-- --------------------------------------------------------

--
-- Table structure for table `element_certificates`
--

CREATE TABLE `element_certificates` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resumeID` int(11) NOT NULL,
  `title` text NOT NULL,
  `description` text NOT NULL,
  `dateObtained` date NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `element_certificates`
--


-- --------------------------------------------------------

--
-- Table structure for table `element_experiances`
--

CREATE TABLE `element_experiances` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resumeID` int(11) NOT NULL,
  `title` text NOT NULL,
  `description` text NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `element_experiances`
--


-- --------------------------------------------------------

--
-- Table structure for table `element_jobs`
--

CREATE TABLE `element_jobs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resumeID` int(11) NOT NULL,
  `companyName` text NOT NULL,
  `position` text NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `city` text NOT NULL,
  `state` text NOT NULL,
  `country` text NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `element_jobs`
--


-- --------------------------------------------------------

--
-- Table structure for table `element_schools`
--

CREATE TABLE `element_schools` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resumeID` int(11) NOT NULL,
  `name` text NOT NULL,
  `type` text NOT NULL,
  `major` text NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `city` text NOT NULL,
  `state` text NOT NULL,
  `country` text NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `element_schools`
--


-- --------------------------------------------------------

--
-- Table structure for table `element_socialNetwork`
--

CREATE TABLE `element_socialNetwork` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resumeID` int(11) NOT NULL,
  `networkName` varchar(100) NOT NULL,
  `profileURL` text NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `element_socialNetwork`
--


-- --------------------------------------------------------

--
-- Table structure for table `element_trainings`
--

CREATE TABLE `element_trainings` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resumeID` int(11) NOT NULL,
  `organizationName` text NOT NULL,
  `position` text NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `city` text NOT NULL,
  `state` text NOT NULL,
  `country` text NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `element_trainings`
--


-- --------------------------------------------------------

--
-- Table structure for table `element_volunteering`
--

CREATE TABLE `element_volunteering` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resumeID` int(11) NOT NULL,
  `organizationName` text NOT NULL,
  `position` text NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `city` text NOT NULL,
  `state` text NOT NULL,
  `country` text NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `element_volunteering`
--


-- --------------------------------------------------------

--
-- Table structure for table `resume`
--

CREATE TABLE `resume` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userID` int(11) NOT NULL,
  `dateCreated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `templateID` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `resume`
--


-- --------------------------------------------------------

--
-- Table structure for table `templates`
--

CREATE TABLE `templates` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `pathToFile` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `templates`
--


-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(260) NOT NULL,
  `password` text NOT NULL,
  `email` varchar(100) NOT NULL,
  `firstName` varchar(100) NOT NULL,
  `middleName` varchar(100) NOT NULL,
  `lastName` varchar(100) NOT NULL,
  `address` text NOT NULL,
  `phoneNumber` varchar(20) NOT NULL,
  `mobileNumber` varchar(20) NOT NULL,
  `faxNumber` varchar(20) NOT NULL,
  `homePage` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `user`
--

