USE cpls;

DROP TABLE IF EXISTS Complaint;
DROP TABLE IF EXISTS Subjct;
DROP TABLE IF EXISTS Complainant;

CREATE TABLE Complainant(
	complainantId INT PRIMARY KEY AUTO_INCREMENT,
    documentCnant VARCHAR(10) UNIQUE,
    nameCnant VARCHAR(45),
    cityCnant VARCHAR(60),
	dateCnant VARCHAR(15),
    liveinCnant VARCHAR(60)
);

CREATE TABLE Subjct(
	subjctId INT PRIMARY KEY AUTO_INCREMENT,
    documentSub VARCHAR(10) UNIQUE,
    nameSub VARCHAR(45),
    citySub VARCHAR(60),
	dateSub VARCHAR(15),
    liveinSub VARCHAR(60)
);

CREATE TABLE Complaint(
	complaintId INT PRIMARY KEY AUTO_INCREMENT,
    complaintNumber VARCHAR(10) UNIQUE,
    cnantRIF INT NOT NULL,
    subRIF INT NOT NULL,
    FOREIGN KEY(cnantRIF) REFERENCES Complainant(complainantId),
    FOREIGN KEY(subRIF) REFERENCES Subjct(subjctId)    
)

SELECT * FROM Complainant;
SELECT * FROM Subjct;
SELECT * FROM Complaint;