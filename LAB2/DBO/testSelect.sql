--select all specimen, of artist 11;
SELECT pota4187.Specimen.Name, pota4187.Specimen.SetCode, pota4187.Painting.Name
FROM pota4187.Specimen, pota4187.Painting
WHERE ArtistID = 11 AND Painting.Name = Specimen.Painting;