-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 09, 2019 at 11:58 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `best_restaurants`
--
CREATE DATABASE IF NOT EXISTS `best_restaurants` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `best_restaurants`;

-- --------------------------------------------------------

--
-- Table structure for table `cuisines`
--

CREATE TABLE `cuisines` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `cuisines`
--

INSERT INTO `cuisines` (`id`, `name`, `description`) VALUES
(1, 'Mexican', 'Mexican cuisine began about 9,000 years ago, when agricultural communities such as the Maya formed, domesticating maize, creating the standard process of corn nixtamalization, and establishing their foodways. Successive waves of other Mesoamerican groups brought with them their own cooking methods.'),
(2, 'Thai', 'Thai cuisine is the national cuisine of Thailand. Thai cooking places emphasis on lightly prepared dishes with strong aromatic components and a spicy edge.'),
(3, 'Italian', 'Italian cuisine is food typical of Italy. It has developed through centuries of social and economic changes, with roots stretching to antiquity.'),
(4, 'Japanese', 'Japanese cuisine encompasses the regional and traditional foods of Japan, which have developed through centuries of political, economic, and social changes. The traditional cuisine of Japan is based on rice with miso soup and other dishes; there is an emphasis on seasonal ingredients.'),
(5, 'French', 'French cuisine consists of the cooking traditions and practices from France. In the 14th century Guillaume Tirel, a court chef known as \"Taillevent\", wrote Le Viandier, one of the earliest recipe collections of medieval France. During that time, French cuisine was heavily influenced by Italian cuisine.'),
(6, 'American', 'American cuisine reflects the history of the United States, blending the culinary contributions of various groups of people from around the world, including indigenous American Indians, African Americans, Asians, Europeans, Pacific Islanders, and South Americans.');

-- --------------------------------------------------------

--
-- Table structure for table `restaurants`
--

CREATE TABLE `restaurants` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `cuisine_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `restaurants`
--

INSERT INTO `restaurants` (`id`, `name`, `description`, `cuisine_id`) VALUES
(1, '9 Dang Fine Thai', 'The signature style of 9 Dang Fine Thaioffers a fresh take on traditional Thai dishes, using only premium ingredients for a new Thai taste.', 2),
(2, 'Thai Peacock', 'Well-flavored Thai food is the attraction at this intimate, pleasant Downtowner turning out a standard roster of curries, stir-fries and rice plates. Lunch specials and prices that are easy on the wallet keep the simple space packed during popular hours.', 2),
(3, 'Khao San Pearl', 'The menu is very simple and consists of small plates which allows our guest to try the different flavors of what our culture has to offer. We use authentic Asian vegetables, when in season, such as apple eggplants, holy basil, and Asian cucumbers. Our signature desserts will comprise of many flavors from Thailand including Thai Tea flavored ice cream and macaroons – all made from scratch. We try our very best to use local products and ingredients while being sustainable and responsible.', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cuisines`
--
ALTER TABLE `cuisines`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `restaurants`
--
ALTER TABLE `restaurants`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cuisines`
--
ALTER TABLE `cuisines`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `restaurants`
--
ALTER TABLE `restaurants`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
