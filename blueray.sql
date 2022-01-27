-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 27, 2022 at 09:16 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.2.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `szop_br`
--

-- --------------------------------------------------------

--
-- Table structure for table `blueray`
--

CREATE TABLE `blueray` (
  `id` int(11) NOT NULL,
  `title` varchar(150) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `director` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `actor` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `genre` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `playtime` int(11) NOT NULL,
  `price` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `blueray`
--

INSERT INTO `blueray` (`id`, `title`, `director`, `actor`, `genre`, `playtime`, `price`) VALUES
(1, 'Hancock ', 'Peter Berg', 'Will Smith', 'Action', 92, 2000),
(3, ' qqqq ', ' qqq ', ' q ', ' q ', 1, 1),
(4, ' s ', ' s ', ' s ', ' s ', 10, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `blueray`
--
ALTER TABLE `blueray`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `blueray`
--
ALTER TABLE `blueray`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
