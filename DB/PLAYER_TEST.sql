--1. 데이터베이스 생성
CREATE DATABASE `GameTest` /*!40100 COLLATE 'utf8mb4_0900_ai_ci' */;

--2.테이블 생성
CREATE TABLE `player` (
	`player_id` INT NOT NULL,
	`username` VARCHAR(50) NULL DEFAULT NULL COLLATE,
	`email` VARCHAR(50) NULL DEFAULT NULL COLLATE ,
	`password_hash` VARCHAR(255) NULL DEFAULT NULL COLLATE ,
	`created.at` TIMESTAMP NULL DEFAULT (now()) ON UPDATE CURRENT_TIMESTAMP,
	`last_login` TIMESTAMP NULL DEFAULT (now()) ON UPDATE CURRENT_TIMESTAMP,
	PRIMARY KEY (player_id),
	UNIQUE INDEX `username` (`username`),
	UNIQUE INDEX `email` (`email`)
)

--3.플레이어 데이터 삽입
INSERT INTO player(username, email, password_hash)VALUES
('hero128', 'hero128@gamil.com', 'hashed1_password1'),
('hero129', 'hero129@gamil.com', 'hashed1_password2'),
('hero130', 'hero130@gamil.com', 'hashed1_password3'),
('hero131', 'hero131@gamil.com', 'hashed1_password4')

--4.플레이어 데이터 조회
SELECT * FROM player
SELECT username, last_login FROM player

--5. 특정 플레이어 정보 업데이트
UPDATE player SET last_login = CURRENT_TIMESTAMP WHERE username = 'hero123'

--6. 조건에 맞는 플레이어 검색
SELECT username, email FROM player WHERE username LIKE '%hero%'

--7. 플레이어 삭제
DELETE FROM player WHERE username = 'hero123'

--8. 플레이어 테이블에 새 열 추가
ALTER TABLE player ADD COLUMN `level` INT DEFAULT 1


--9. 모든 플레이어의 레벨을 1증가
UPDATE player SET `level` = `level` + 1

--10. 가장 레벨이 높은 플레이어 가져오기
SELECT username, `level` FROM player ORDER BY `level` DESC LIMIT 1