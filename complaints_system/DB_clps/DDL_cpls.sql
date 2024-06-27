USE cpls;

DROP TABLE IF EXISTS Complaint;
DROP TABLE IF EXISTS Subjct;
DROP TABLE IF EXISTS Complainant;

CREATE TABLE Complainant(
	complainantId INT PRIMARY KEY AUTO_INCREMENT,
    documentCnant VARCHAR(10) NOT NULL UNIQUE,
    nameCnant VARCHAR(45) NOT NULL,
    cityCnant VARCHAR(60) NOT NULL,
	dateCnant DATE NOT NULL,
    liveinCnant VARCHAR(60) NOT NULL
);

CREATE TABLE Subjct(
	subjctId INT PRIMARY KEY AUTO_INCREMENT,
    documentSub VARCHAR(10) NOT NULL UNIQUE,
    nameSub VARCHAR(45) NOT NULL,
    citySub VARCHAR(60) NOT NULL,
	dateSub DATE NOT NULL,
    liveinSub VARCHAR(60) NOT NULL
);

CREATE TABLE Complaint(
	complaintId INT PRIMARY KEY AUTO_INCREMENT,
    complaintNumber VARCHAR(10) NOT NULL UNIQUE,
    cnantRIF INT NOT NULL,
    subRIF INT NOT NULL,
    FOREIGN KEY(cnantRIF) REFERENCES Complainant(complainantId),
    FOREIGN KEY(subRIF) REFERENCES Subjct(subjctId)    
)

SELECT * FROM Complaint 
	JOIN Complainant ON Complainant.complainantId = Complaint.cnantRIF
    JOIN Subjct ON Subjct.subjctId = Complaint.subRIF