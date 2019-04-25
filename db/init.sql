USE studentadministrationstore;
	    
CREATE TABLE IF NOT EXISTS Students (
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Name VARCHAR(100) NULL DEFAULT NULL,
	Address VARCHAR(255) NULL DEFAULT NULL,
	Email VARCHAR(255) NULL DEFAULT NULL,
	PhoneNumber INTEGER NULL DEFAULT NULL,
	Historic BIT(1) NOT NULL DEFAULT b'0',
	PRIMARY KEY (Id) 
);	

CREATE TABLE IF NOT EXISTS Teachers (
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Name VARCHAR(100) NULL DEFAULT NULL,
	Address VARCHAR(255) NULL DEFAULT NULL,
	Email VARCHAR(255) NULL DEFAULT NULL,
	PhoneNumber INTEGER NULL DEFAULT NULL,
	Historic BIT(1) NOT NULL DEFAULT b'0',
	PRIMARY KEY (Id) 
);
	
CREATE TABLE IF NOT EXISTS Courses (
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Title VARCHAR(255) NULL DEFAULT NULL,
	Description VARCHAR(16384) NULL DEFAULT NULL,
	Historic BIT(1) NOT NULL DEFAULT b'0',
	SchoolId INTEGER NULL DEFAULT NULL,
	PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS CourseStudents (
	CourseId INTEGER NOT NULL,
	StudentId INTEGER NOT NULL,
	Score INTEGER NULL DEFAULT NULL,
	Historic BIT(1) NOT NULL DEFAULT b'0',
	PRIMARY KEY (CourseId, StudentId)
);

CREATE TABLE IF NOT EXISTS CourseTeachers (
	CourseId INTEGER NOT NULL,
	TeacherId INTEGER NOT NULL,
	Historic BIT(1) NOT NULL DEFAULT b'0',
	PRIMARY KEY (CourseId, TeacherId)
);

CREATE TABLE IF NOT EXISTS Schools (
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Name VARCHAR(255) NULL DEFAULT NULL,
	Address VARCHAR(255) NULL DEFAULT NULL,
	EducationLevel SMALLINT NULL DEFAULT NULL,
	SchoolType SMALLINT NULL DEFAULT NULL,
	Historic BIT(1) NOT NULL DEFAULT b'0',
	PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS Lessons (
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Description VARCHAR(16384) NULL DEFAULT NULL,
	Location VARCHAR(511) NULL DEFAULT NULL,
	DateTime DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	Duration SMALLINT NULL DEFAULT NULL,
	CourseId INTEGER NULL DEFAULT NULL,
	Historic BIT(1) NOT NULL DEFAULT b'0',
	PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS DataObjects (
	Id INTEGER NOT NULL AUTO_INCREMENT,
	DataType SMALLINT NOT NULL DEFAULT '0',
	Information VARCHAR(16384) NULL DEFAULT NULL,
	LessonId INTEGER NULL DEFAULT NULL,
	CourseId INTEGER NULL DEFAULT NULL,
	Historic BIT(1) NOT NULL DEFAULT b'0',
	PRIMARY KEY (Id)
);
