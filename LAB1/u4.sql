-- Pavadinimas ir ISBN knygos, kurios egzempliori? bibliotekoje yra daugiausiai.
WITH Knygos_egzemplioriai
	AS	( SELECT Stud.Knyga.Pavadinimas, Stud.Knyga.ISBN, COUNT(*) AS Skaicius
		FROM Stud.Knyga, Stud.Egzempliorius
		WHERE Stud.Egzempliorius.ISBN = Stud.Knyga.ISBN
		GROUP BY Stud.Knyga.ISBN),
	Didziausias (m)
	AS  (SELECT MAX(Skaicius) FROM Knygos_egzemplioriai)
SELECT Pavadinimas, ISBN FROM Knygos_egzemplioriai, Didziausias
WHERE m = Skaicius;
