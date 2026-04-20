-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: sql213.hstn.me
-- Czas generowania: 09 Kwi 2026, 10:16
-- Wersja serwera: 11.4.10-MariaDB
-- Wersja PHP: 7.2.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `mseet_41306550_komodohubDB`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Access_Code`
--

CREATE TABLE `Access_Code` (
  `code_id` int(11) NOT NULL,
  `school_id` int(11) NOT NULL,
  `code` varchar(100) NOT NULL,
  `created_by` int(11) NOT NULL,
  `expires_at` datetime NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'ACTIVE'
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Zrzut danych tabeli `Access_Code`
--

INSERT INTO `Access_Code` (`code_id`, `school_id`, `code`, `created_by`, `expires_at`, `status`) VALUES
(4, 1, 'coolcode99', 33, '2026-12-31 00:00:00', 'ACTIVE'),
(5, 5, 'CLASS2026', 51, '2026-04-11 15:10:27', 'ACTIVE');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Activity`
--

CREATE TABLE `Activity` (
  `activity_id` int(11) NOT NULL,
  `program_id` int(11) NOT NULL,
  `title` varchar(150) NOT NULL,
  `description` varchar(500) DEFAULT NULL,
  `activity_type` varchar(50) NOT NULL,
  `due_date` date DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `image_path` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `Activity`
--

INSERT INTO `Activity` (`activity_id`, `program_id`, `title`, `description`, `activity_type`, `due_date`, `created_at`, `image_path`) VALUES
(46, 1, 'Javan Rhino Conservation Walk', 'Students will track and document rhino footprints', 'myTeacher', '2026-07-20', '2026-04-08 20:39:01', 'http://komodoproject.zya.me/uploads/activities/act_69d6bce5786e25.91160643.jpg');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Enrolment`
--

CREATE TABLE `Enrolment` (
  `enrolment_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `program_id` int(11) NOT NULL,
  `enrolled_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `Enrolment`
--

INSERT INTO `Enrolment` (`enrolment_id`, `user_id`, `program_id`, `enrolled_at`) VALUES
(1, 37, 2, '2026-04-07 20:46:37'),
(2, 37, 3, '2026-04-07 20:50:07'),
(3, 37, 1, '2026-04-07 20:50:45'),
(4, 51, 2, '2026-04-08 02:15:49');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Library_Item`
--

CREATE TABLE `Library_Item` (
  `item_id` int(11) NOT NULL,
  `school_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `item_type` varchar(50) NOT NULL,
  `title` varchar(150) NOT NULL,
  `content_url` varchar(500) DEFAULT NULL,
  `visibility` varchar(20) NOT NULL DEFAULT 'ORG_ONLY',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Program`
--

CREATE TABLE `Program` (
  `program_id` int(11) NOT NULL,
  `title` varchar(150) NOT NULL,
  `description` varchar(500) DEFAULT NULL,
  `organisation_type` varchar(50) NOT NULL,
  `organisation_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `Program`
--

INSERT INTO `Program` (`program_id`, `title`, `description`, `organisation_type`, `organisation_id`, `created_at`) VALUES
(1, 'Javan Rhino Conservation', 'Learn about and contribute to Javan Rhino conservation efforts in Ujung Kulon', 'SCHOOL', 1, '2026-04-07 19:45:03'),
(2, 'Sumatran Tiger Protection', 'Help monitor and protect the critically endangered Sumatran Tiger population', 'SCHOOL', 1, '2026-04-07 19:45:03'),
(3, 'Bali Myna Breeding Program', 'Support the breeding and release program for the endangered Bali Myna bird', 'COMMUNITY', 1, '2026-04-07 19:45:03');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `public_library`
--

CREATE TABLE `public_library` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `author` varchar(150) NOT NULL,
  `animal_name` varchar(150) NOT NULL,
  `species` varchar(150) NOT NULL,
  `habitat` varchar(255) NOT NULL,
  `conservation_status` varchar(100) NOT NULL,
  `content` text NOT NULL,
  `image_url` varchar(500) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp()
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Zrzut danych tabeli `public_library`
--

INSERT INTO `public_library` (`id`, `title`, `author`, `animal_name`, `species`, `habitat`, `conservation_status`, `content`, `image_url`, `created_at`) VALUES
(1, 'Komodo Dragon Sighting Report', 'MyTeacher', 'Komodo Dragon', 'Varanus komodoensis', 'Komodo National Park, Indonesia', 'Endangered', 'The Komodo dragon is the largest living lizard in the world. It can grow up to 3 metres long and uses a venomous bite to weaken prey. Komodo dragons are found only on a few Indonesian islands. They are powerful hunters and also important to their ecosystem.', 'http://komodoproject.zya.me/pictures/1.jpg', '2026-04-08 18:24:15'),
(2, 'Javan Rhino Information Sheet', 'majd1', 'Javan Rhinoceros', 'Rhinoceros sondaicus', 'Ujung Kulon National Park, Indonesia', 'Critically Endangered', 'The Javan rhinoceros is one of the rarest large mammals on Earth. It is extremely shy and lives in dense rainforest areas. Fewer than one hundred individuals are believed to survive in the wild, making conservation efforts especially important.', 'http://komodoproject.zya.me/pictures/2.jpg', '2026-04-08 18:24:15'),
(3, 'Sumatran Tiger Conservation Note', 'Patrick', 'Sumatran Tiger', 'Panthera tigris sumatrae', 'Sumatra, Indonesia', 'Critically Endangered', 'The Sumatran tiger is the smallest surviving tiger subspecies. It is known for its dark orange coat and close black stripes. Habitat loss and poaching are major threats to its survival. Protecting forest habitats is essential for this species.', 'http://komodoproject.zya.me/pictures/3.jpg', '2026-04-08 18:24:15'),
(4, 'Bali Myna Classroom Finding', 'karim', 'Bali Myna', 'Leucopsar rothschildi', 'Bali, Indonesia', 'Critically Endangered', 'The Bali myna is a striking white bird with blue skin around its eyes. It is one of the rarest birds in the world. Illegal trapping and habitat loss have pushed it close to extinction, but breeding and release programmes are helping.', 'http://komodoproject.zya.me/pictures/4.jpg', '2026-04-08 18:24:15'),
(5, 'Javan Eagle Research Note', 'gg1', 'Javan Eagle', 'Nisaetus bartelsi', 'Java, Indonesia', 'Endangered', 'The Javan eagle is a bird of prey native to Java and is sometimes associated with the national symbol of Indonesia. It lives in forested mountain regions and depends on healthy woodland habitats for nesting and hunting.', 'http://komodoproject.zya.me/pictures/5.jpg', '2026-04-08 18:24:15');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `School`
--

CREATE TABLE `School` (
  `school_id` int(11) NOT NULL,
  `name` varchar(150) NOT NULL,
  `region` varchar(100) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `School`
--

INSERT INTO `School` (`school_id`, `name`, `region`, `created_at`) VALUES
(1, 'Jakarta Green School', 'Jakarta', '2026-03-05 14:56:55'),
(2, 'Ujung Raya Primary School', 'Ujung Kulon', '2026-03-09 13:03:13'),
(3, 'Bali Conservation Academy', 'Bali', '2026-03-09 13:03:13'),
(4, 'Surabaya Green School', 'Surabaya', '2026-03-09 13:03:13'),
(5, 'Bandung Nature School', 'Bandung', '2026-03-09 13:03:13'),
(6, 'Medan Wildlife School', 'Medan', '2026-03-09 13:03:13'),
(7, 'Yogyakarta Eco School', 'Yogyakarta', '2026-03-09 13:03:13'),
(8, 'Makassar Marine School', 'Makassar', '2026-03-09 13:03:13'),
(9, 'Lombok Island School', 'Lombok', '2026-03-09 13:03:13'),
(10, 'Borneo Forest School', 'Kalimantan', '2026-03-09 13:03:13'),
(11, 'Papua Conservation School', 'Papua', '2026-03-09 13:03:13');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `sighting_report`
--

CREATE TABLE `sighting_report` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `species` varchar(200) NOT NULL,
  `location` varchar(255) NOT NULL,
  `sighting_date` date NOT NULL,
  `description` text DEFAULT NULL,
  `image_path` varchar(500) DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Zrzut danych tabeli `sighting_report`
--

INSERT INTO `sighting_report` (`id`, `username`, `species`, `location`, `sighting_date`, `description`, `image_path`, `created_at`) VALUES
(30, 'myTeacher', 'Sumatran Tiger', 'Ujung kulon National Park', '2026-03-05', 'I was walking by the river and i spotted it. It was on a Thursday.', '', '2026-04-08 13:33:55'),
(31, 'myTeacher', 'Javan Rhinoceros', 'Next to the lake', '2026-04-09', 'i saw while i was walking next to the lake', '', '2026-04-09 07:03:24');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Submissions`
--

CREATE TABLE `Submissions` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `title` varchar(150) NOT NULL,
  `report_text` text NOT NULL,
  `image_path` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `category` varchar(255) NOT NULL,
  `is_school` tinyint(1) NOT NULL DEFAULT 0,
  `is_public` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Zrzut danych tabeli `Submissions`
--

INSERT INTO `Submissions` (`id`, `username`, `title`, `report_text`, `image_path`, `created_at`, `category`, `is_school`, `is_public`) VALUES
(3, 'majd', 'vzgvz', 'zdvzs', NULL, '2026-04-07 00:28:45', '', 0, 0),
(4, 'majd', 'sdvsdv', 'sdvsdvsdv', NULL, '2026-04-07 00:28:55', '', 0, 0),
(5, 'majd', 'majd', 'derbali', NULL, '2026-04-07 00:56:35', '', 0, 0),
(2, 'majd', 'Komodo Habitat Research', 'This report explains the habitat of Komodo dragons and conservation actions.', '', '2026-03-12 08:02:25', '', 0, 0),
(6, 'majd', 'karim', 'karim', NULL, '2026-04-07 01:02:26', '', 0, 0),
(7, 'myTeacher', 'karim assignment', 'this an assignment for 5004cmd', NULL, '2026-04-07 14:07:11', '', 0, 0),
(8, 'myTeacher', 'karim', '123 karim', NULL, '2026-04-07 14:08:38', '', 0, 0),
(9, 'karim1', 'karim', '1234 kossomak', NULL, '2026-04-07 14:10:41', '', 0, 0),
(10, 'majd', 'snake', 'yep', NULL, '2026-04-07 14:13:02', '', 0, 0),
(11, 'majd', 'erg', 'ergege', NULL, '2026-04-07 22:23:57', '', 0, 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Subscription`
--

CREATE TABLE `Subscription` (
  `sub_id` int(11) NOT NULL,
  `school_id` int(11) NOT NULL,
  `plan` varchar(50) DEFAULT 'BASIC',
  `status` varchar(20) DEFAULT 'ACTIVE',
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Zrzut danych tabeli `Subscription`
--

INSERT INTO `Subscription` (`sub_id`, `school_id`, `plan`, `status`, `start_date`, `end_date`, `created_at`) VALUES
(1, 1, 'BASIC', 'ACTIVE', '2026-01-01', '2026-03-08', '2026-04-07 22:47:33');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Teacher_Note`
--

CREATE TABLE `Teacher_Note` (
  `note_id` int(11) NOT NULL,
  `submission_id` int(11) NOT NULL,
  `teacher_id` int(11) NOT NULL,
  `note_text` varchar(1000) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `Teacher_Note`
--

INSERT INTO `Teacher_Note` (`note_id`, `submission_id`, `teacher_id`, `note_text`, `created_at`) VALUES
(6, 5, 0, 'test', '2026-04-07 09:42:40'),
(7, 5, 0, 'nice', '2026-04-07 09:43:00'),
(8, 6, 0, 'niec majd', '2026-04-07 09:44:27'),
(9, 6, 0, 'majd', '2026-04-07 09:46:35'),
(10, 6, 0, 'it is actually working kossom il kon', '2026-04-07 09:48:47'),
(11, 2, 0, '86%', '2026-04-07 09:49:51'),
(12, 3, 0, 'nice', '2026-04-07 10:53:30'),
(13, 10, 0, 'good job ', '2026-04-08 00:21:14'),
(14, 2, 0, 'good', '2026-04-08 18:35:17'),
(15, 11, 0, 'good job ', '2026-04-09 14:04:11');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `school_id` int(11) DEFAULT NULL,
  `role` varchar(50) NOT NULL,
  `name` varchar(150) NOT NULL,
  `email` varchar(150) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `avatar_theme` varchar(50) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `messages` longtext DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`user_id`, `school_id`, `role`, `name`, `email`, `password_hash`, `avatar_theme`, `created_at`, `messages`, `is_active`) VALUES
(0, 1, 'TEACHER', 'Abuba', 'budi@school.org', '1234', 'Green', '2026-03-05 14:56:55', NULL, 1),
(1, 1, 'STUDENT', 'Aisha Rahman', 'aisha.rahman@school.org', 'hash_a1', 'Blue', '2026-03-07 22:52:24', NULL, 1),
(9, 1, 'STUDENT', 'Daniel Okoro', 'daniel.okoro@school.org', 'hash_b2', 'Red', '2026-03-07 22:59:48', NULL, 1),
(10, 1, 'STUDENT', 'Mei Lin', 'mei.lin@school.org', 'hash_cs', 'Purple', '2026-03-07 22:59:48', NULL, 1),
(11, 1, 'STUDENT', 'Lucas Pereira', 'lucas.pereira@school.org', 'hash_d4', 'Yellow', '2026-03-07 23:03:05', NULL, 1),
(12, 1, 'STUDENT', 'Sofia Dimitri', 'sofia.dimitri@school.org', 'hash_e5', 'Green', '2026-03-07 23:03:05', NULL, 1),
(13, 1, 'STUDENT', 'Haruto Tanaka', 'haruto.tanaka@school.org', 'hash_f6', 'Orange', '2026-03-07 23:06:19', NULL, 1),
(14, 1, 'STUDENT', 'Emma Johansson', 'emma.johansson@school.org', 'hash_g7', 'Pink', '2026-03-07 23:06:19', NULL, 1),
(15, 1, 'STUDENT', 'Omar Al-Hassan', 'omar.hassan@school.org', 'hash_h8', 'Cyan', '2026-03-07 23:09:10', NULL, 1),
(16, 1, 'STUDENT', 'Priya Nair', 'priya.nair@school.org', 'hash_i9', 'Teal', '2026-03-07 23:09:10', NULL, 1),
(17, 1, 'STUDENT', 'Ethan Miller', 'ethan.miller@school.org', 'hash_j10', 'Indigo', '2026-03-07 23:12:02', NULL, 1),
(18, 1, 'TEACHER', 'Sarah Collins', 'sarah.collins@school.org', 'hash_k11', 'Green', '2026-03-07 23:12:02', NULL, 1),
(19, 1, 'TEACHER', 'Ahmed Suleiman', 'ahmed.suleiman@school.org', 'hash_l12', 'Blue', '2026-03-07 23:14:28', NULL, 1),
(20, 1, 'TEACHER', 'Laura Kim', 'laura.kim@school.org', 'hash_m13', 'Purple', '2026-03-07 23:14:28', NULL, 1),
(21, 1, 'TEACHER', 'Jorge Alvarez', 'jorge.alvarez@school.org', 'hash_n14', 'Red', '2026-03-07 23:17:01', NULL, 1),
(22, 1, 'TEACHER', 'Fatima Noor', 'fatima.noor@school.org', 'hash_o15', 'Yellow', '2026-03-07 23:17:01', NULL, 1),
(23, 1, 'ADMIN', 'Maria Rossi', 'maria.rossi@school.org', 'hash_p16', 'Gold', '2026-03-07 23:20:01', NULL, 1),
(24, 1, 'ADMIN', 'John Carter', 'john.carter@school.org', 'hash_q17', 'Silver', '2026-03-07 23:20:01', NULL, 1),
(25, 1, 'ADMIN', 'Helen Wu', 'helen.wu@school.org', 'hash_r18', 'Blue', '2026-03-07 23:22:30', NULL, 1),
(26, 1, 'ADMIN', 'Liam Grant', 'liam.grant@school.org', 'hash_s19', 'Green', '2026-03-07 23:22:30', NULL, 1),
(27, 1, 'ADMIN', 'Omar Idris', 'omar.idris@schoool.org', 'hasht_20', 'Red', '2026-03-07 23:23:25', NULL, 1),
(33, 1, 'ADMIN', 'Brian', 'someemail@gmail.com', '$2y$10$MHUW.pqn.RYdxJlsk7Qim.e8jaEjoBosswDag2o2XOnCDngwfTxs.', 'default', '2026-03-10 23:41:34', NULL, 1),
(34, 1, 'student', 'TestUser', 'test@test.com', '$2y$10$g3IQpH9pNbCVsWyHL.gt4.H.1jMPXwLje3qxx0uUErhLwBx6bk/xq', 'default', '2026-03-11 12:14:25', NULL, 1),
(36, 1, 'student', 'test', 'test@gmail.com', '$2y$10$eA5WK1Mf/YhXgCoa1vPvoeVBrH9ygpDGXa7gkHV1bzoFDpde1/jwO', 'default', '2026-03-12 11:29:21', NULL, 1),
(37, 1, 'ADMIN', 'majd', 'Derbalimajd.04@gmail.com', '$2y$10$KZ9fBhDVwzCT3/U0k/sYOOINnYWp5llMmiYpn7zMBHOaiq0/rZKCm', 'default', '2026-03-12 15:00:34', NULL, 1),
(38, 1, 'student', 'patric11', 'patuche011@gmail.com', '$2y$10$wWZMwie50Xn8XdR8S8hNpOXtV9bpLn0ZJVFrbcod.qrA7DpyrNpOm', 'default', '2026-03-12 15:56:53', NULL, 1),
(39, 1, 'student', 'Thanni914', 'thanni914@gmail.com', '$2y$10$SHbV3ZyhhsAn4Z1x/szRsu5wlCZ/QOOAWRIyfkllxi66GezMH1kN6', 'default', '2026-03-16 15:59:54', NULL, 1),
(40, 1, 'student', 'gg', 'mmm@gma.com', '$2y$10$MsaSJovkSDhbbWd.bBaqP.mVBIIHz5l.dVTimnr8hU4a4wEV1ksnq', 'default', '2026-03-16 16:39:19', NULL, 1),
(41, 1, 'student', 'aj', 'gg@yahoo', '$2y$10$Tia4ve9v1C7hOpMEfv3wI..hPME1a83MPO8TWvqVXkivIpHBKLYTG', 'default', '2026-03-16 16:41:00', NULL, 1),
(42, 1, 'student', 'gg1', 'gg1@gmail.com', '$2y$10$AG.DAkL5dBRgdEklIDM2cu8asTAx6Z.YzIEIUqEFe9IJhIPL3mVVe', 'default', '2026-03-16 16:44:44', NULL, 1),
(43, 1, 'student', 'karimtest@gmail.com', 'karimtest@gmail.com', '$2y$10$bMLyhspjtyGBOGQyevheGeYr5DjErBO.SFMjgtcZkWF.j7hAeffgW', 'default', '2026-04-03 17:56:26', NULL, 1),
(46, 1, 'student', 'NewUser2', 'newuser2@test.com', '$2y$10$K61W8dZFoTaWvYzvUSFS1eanJn6NuKbgVIz/Pb7Rl6qT3I8nz6Gl6', 'default', '2026-04-03 18:38:44', NULL, 1),
(47, 1, 'student', 'patrick123@gmail.com', 'patrick123@gmail.com', '$2y$10$3Nk2UCI3BLIg/MUOD9Cw0ukdAFXN9Jj.F7vLHFXZLMwJQHrOqCN9y', 'default', '2026-04-03 18:42:14', NULL, 1),
(48, 1, 'student', 'karim', 'karim123@gmail.com', '$2y$10$h8b5MYQkiqp/0NkigoIxDuSA6q18TdorCdKFweKKfUKbx/K6ZxxmG', 'default', '2026-04-03 18:45:41', NULL, 1),
(49, 1, 'student', 'karim1', 'karim12@gmail.com', '$2y$10$xDdrEJVCMVWSNfUbya5xye7jRyooc/GQ7xIa7/Ik5816bev0K.lA6', 'default', '2026-04-03 18:52:48', NULL, 1),
(50, 1, 'student', 'karim2', 'karim12@school.org', '$2y$10$qiNkjT.nupIJ1fudqGQUMuAhIaDkykPSmQVy.eLid1jgmIv.YWz6C', 'default', '2026-04-04 18:48:38', NULL, 1),
(51, 1, 'TEACHER', 'MyTeacher', 'teacher@school.org', '$2y$10$QDWuPMoJ5Ot/TWO0r1l8OOArkCEMzwpjGGp18xDSCAyV31S0l9A6e', 'default', '2026-04-04 19:08:44', '395jjsdZeoCe5mmXEwoRJg==:4eE5fIUMfsWTRrwFvWMiww==\ndgbuM9sA296uvwFcGpXzFQ==:RmnTcLHhCgvUERtVZ1cjew==\nkNJic0v2HrEERXQWS/IPCQ==:Hlgte3ZkDa/p/Yo7iV0fbw==\nMHr8OysTzURHx4usGQMwVQ==:R8gP5LhYIrcLXKnSboXXeMNtey+OSTvjSxcVlrsYK2rl7m3xoV/Unx7gD1+kZk23', 1),
(52, 1, 'STUDENT', 'majd1', 'azdazd@gams.co', '$2y$10$.FrTLqeB37647Bz0C3iu7ufTgtbE8TkvHPfdkFRw71yRx.x0VHTG6', 'default', '2026-04-07 11:14:37', NULL, 1),
(53, 1, 'STUDENT', 'Patrick', 'uchec3@coventry.ac.uk', '$2y$10$NOR5zerO5C.IZ3pMEhwG9eZ5vypx94Bf230jIuggfMVBsEh0hAdH6', 'default', '2026-04-07 11:28:37', NULL, 1),
(54, 1, 'STUDENT', 'michael', 'patrickiche2006@gmail.com', '$2y$10$wYXdW6Yg/.qoMBW9OnGhN.oWGFd1.dIeikQNwETrkn506EloQAMFK', 'default', '2026-04-07 22:53:57', NULL, 1),
(55, 1, 'STUDENT', 'ahmed', 'ahmed@gmail.com', '$2y$10$riwyGfqg2NLHUmnWr7Z7z.Bu/lHNldu/vfn7Cvm8lVz/GHzZwtxua', 'default', '2026-04-08 16:26:15', NULL, 1),
(56, 1, 'STUDENT', 'student', 'stu@gmail.com', '$2y$10$OtuawBAhKDV.62Ew/U.ne.AHFCuMVH3D/Bk/bkgnw4tn7llBke9U2', 'default', '2026-04-08 19:57:01', NULL, 1),
(57, 1, 'STUDENT', 'ahmad', 'derb@hhh.cu', '$2y$10$fhFeYWdp0bs3woiCwN9oZOk7nBTTBBgFSCkLQ0uH5BuOeIPpaev3e', 'default', '2026-04-08 19:58:16', NULL, 1),
(58, 1, 'STUDENT', 'CoolStudent', 'student@gmail.com', '$2y$10$XaUbFSO9dBcOtH79FbAA8.n0AovGaQmeNU6mcvYjAq7N6j5gpGDoy', 'default', '2026-04-08 20:40:49', NULL, 1),
(59, 1, 'STUDENT', 'muha', '419@gmail.com', '$2y$10$VKcihilIzmmIEs8kiHDNA.iCasHh.npYUPhHFhie9BpmopNoUkzBC', 'default', '2026-04-09 13:09:28', NULL, 1);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `Access_Code`
--
ALTER TABLE `Access_Code`
  ADD PRIMARY KEY (`code_id`),
  ADD UNIQUE KEY `code` (`code`),
  ADD KEY `fk_accesscode_school` (`school_id`),
  ADD KEY `fk_accesscode_user` (`created_by`);

--
-- Indeksy dla tabeli `Activity`
--
ALTER TABLE `Activity`
  ADD PRIMARY KEY (`activity_id`);

--
-- Indeksy dla tabeli `Enrolment`
--
ALTER TABLE `Enrolment`
  ADD PRIMARY KEY (`enrolment_id`),
  ADD UNIQUE KEY `ux_user_program` (`user_id`,`program_id`),
  ADD KEY `ix_enrolment_user` (`user_id`),
  ADD KEY `ix_enrolment_program` (`program_id`);

--
-- Indeksy dla tabeli `Library_Item`
--
ALTER TABLE `Library_Item`
  ADD PRIMARY KEY (`item_id`),
  ADD KEY `ix_libraryitem_school` (`school_id`),
  ADD KEY `ix_libraryitem_user` (`user_id`);

--
-- Indeksy dla tabeli `Program`
--
ALTER TABLE `Program`
  ADD PRIMARY KEY (`program_id`);

--
-- Indeksy dla tabeli `public_library`
--
ALTER TABLE `public_library`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `School`
--
ALTER TABLE `School`
  ADD PRIMARY KEY (`school_id`);

--
-- Indeksy dla tabeli `sighting_report`
--
ALTER TABLE `sighting_report`
  ADD PRIMARY KEY (`id`),
  ADD KEY `species` (`species`);

--
-- Indeksy dla tabeli `Submissions`
--
ALTER TABLE `Submissions`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `Subscription`
--
ALTER TABLE `Subscription`
  ADD PRIMARY KEY (`sub_id`);

--
-- Indeksy dla tabeli `Teacher_Note`
--
ALTER TABLE `Teacher_Note`
  ADD PRIMARY KEY (`note_id`),
  ADD KEY `ix_teachernote_submission` (`submission_id`),
  ADD KEY `ix_teachernote_teacher` (`teacher_id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD KEY `ix_users_school_id` (`school_id`),
  ADD KEY `name` (`name`),
  ADD KEY `role` (`role`),
  ADD KEY `name_2` (`name`),
  ADD KEY `password_hash` (`password_hash`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `Access_Code`
--
ALTER TABLE `Access_Code`
  MODIFY `code_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `Activity`
--
ALTER TABLE `Activity`
  MODIFY `activity_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT dla tabeli `Enrolment`
--
ALTER TABLE `Enrolment`
  MODIFY `enrolment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT dla tabeli `Library_Item`
--
ALTER TABLE `Library_Item`
  MODIFY `item_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `Program`
--
ALTER TABLE `Program`
  MODIFY `program_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `public_library`
--
ALTER TABLE `public_library`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `School`
--
ALTER TABLE `School`
  MODIFY `school_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT dla tabeli `sighting_report`
--
ALTER TABLE `sighting_report`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT dla tabeli `Submissions`
--
ALTER TABLE `Submissions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT dla tabeli `Subscription`
--
ALTER TABLE `Subscription`
  MODIFY `sub_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `Teacher_Note`
--
ALTER TABLE `Teacher_Note`
  MODIFY `note_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=60;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `Enrolment`
--
ALTER TABLE `Enrolment`
  ADD CONSTRAINT `fk_enrolment_program` FOREIGN KEY (`program_id`) REFERENCES `Program` (`program_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_enrolment_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE;

--
-- Ograniczenia dla tabeli `Library_Item`
--
ALTER TABLE `Library_Item`
  ADD CONSTRAINT `fk_libraryitem_school` FOREIGN KEY (`school_id`) REFERENCES `School` (`school_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_libraryitem_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`);

--
-- Ograniczenia dla tabeli `Teacher_Note`
--
ALTER TABLE `Teacher_Note`
  ADD CONSTRAINT `fk_teachernote_teacher` FOREIGN KEY (`teacher_id`) REFERENCES `users` (`user_id`);

--
-- Ograniczenia dla tabeli `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_users_school` FOREIGN KEY (`school_id`) REFERENCES `School` (`school_id`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
