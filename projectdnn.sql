-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 10 jun 2018 om 15:39
-- Serverversie: 10.1.26-MariaDB
-- PHP-versie: 7.0.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projectdnn`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `datapool`
--

CREATE TABLE `datapool` (
  `id` int(10) NOT NULL,
  `name` varchar(100) NOT NULL,
  `size` float NOT NULL,
  `status` int(2) NOT NULL DEFAULT '0',
  `project_id` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `datapool`
--

INSERT INTO `datapool` (`id`, `name`, `size`, `status`, `project_id`) VALUES
(1, 'dataset0.csv', 33, 0, 11),
(2, 'dataset1.csv', 33, 1, 11),
(3, 'dataset2.csv', 33, 2, 11),
(4, 'dataset0.csv', 50, 0, 12);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `projects`
--

CREATE TABLE `projects` (
  `id` int(10) NOT NULL,
  `token` varchar(64) NOT NULL,
  `name` varchar(100) NOT NULL,
  `desc` varchar(500) NOT NULL,
  `picture` varchar(100) NOT NULL DEFAULT 'projects/default.png',
  `user_id` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `projects`
--

INSERT INTO `projects` (`id`, `token`, `name`, `desc`, `picture`, `user_id`) VALUES
(10, 'DSFG-80563d77c06527e2bf3c45948186b12e310c1c4b', 'dsfg', 'sdfg', 'projects/default.png', 1),
(11, 'MNIST20-7c304963cec03b5831792669c79756f6bdd73d2c', 'MNIST20', 'This is a sample project\r\n', 'projects/default.png', 1),
(12, 'STENDENS-ab7a0512b383591b0c137d6ed1953c48634431c7', 'stendensomethign', 'kjashklajsdf\r\n', 'projects/default.png', 1),
(13, 'APPLE IN-dd1bb3fe9373691c1b4a6a203629ccaa3e01d327', 'Apple INC', 'this is something', 'projects/default.png', 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

CREATE TABLE `users` (
  `id` int(10) NOT NULL,
  `username` varchar(32) NOT NULL,
  `name` text NOT NULL,
  `email` varchar(200) NOT NULL,
  `password` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`id`, `username`, `name`, `email`, `password`) VALUES
(1, 'gerritman123', 'Gerrit Luimstra', 'gerrit.luimstra@ziggo.nl', '$2y$10$y7erBXNjc6ltUq.KJyruruvgZ19IZZvlW8brN7bvA4nlAS5az2gsu');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `datapool`
--
ALTER TABLE `datapool`
  ADD PRIMARY KEY (`id`),
  ADD KEY `datapool_projects` (`project_id`);

--
-- Indexen voor tabel `projects`
--
ALTER TABLE `projects`
  ADD PRIMARY KEY (`id`),
  ADD KEY `project_user` (`user_id`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `datapool`
--
ALTER TABLE `datapool`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT voor een tabel `projects`
--
ALTER TABLE `projects`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `datapool`
--
ALTER TABLE `datapool`
  ADD CONSTRAINT `datapool_projects` FOREIGN KEY (`project_id`) REFERENCES `projects` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Beperkingen voor tabel `projects`
--
ALTER TABLE `projects`
  ADD CONSTRAINT `project_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
