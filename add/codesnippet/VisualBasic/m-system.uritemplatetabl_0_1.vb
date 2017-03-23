        Dim prefix As New Uri("http://localhost/")

        ' Create a series of templates
        Dim weatherByCity = New UriTemplate("weather/ state}/ city}")
        Dim weatherByCountry = New UriTemplate("weather/ country}/ village}")
        Dim weatherByState = New UriTemplate("weather/ state}")
        Dim traffic = New UriTemplate("traffic/*")
        Dim wildcard = New UriTemplate("*")

        ' Create a template table
        Dim table As New UriTemplateTable(prefix)
        ' Add each template to the table with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        table.MakeReadOnly(True)

        ' Call Match to retrieve some match results:
        Dim results As ICollection(Of UriTemplateMatch)
        results = Nothing
        Dim weatherInSeattle As New Uri("http://localhost/weather/Washington/Seattle")

        results = table.Match(weatherInSeattle)
        If (results IsNot Nothing) Then

            Console.WriteLine("Matching templates:")
            For Each match As UriTemplateMatch In results
                Console.WriteLine("    0}", match.Template)
            Next
        End If