using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WhatIsInAName.Infrastructure.Entities;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.Infrastructure.Data
{
    internal class SqlDataProvider : IDataProvider
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WhatInTheName;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<VariableWord> GetVariableWords(List<string> words)
        {
            var variableWords = new List<VariableWord>();

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("stp_Search", con) { CommandType = CommandType.StoredProcedure })
                {
                    using (var table = new DataTable())
                    {
                        table.Columns.Add("Value", typeof(string));

                        foreach (var word in words)
                        {
                            table.Rows.Add(word);
                        }

                        var pList = new SqlParameter("@TvpWords", SqlDbType.Structured);
                        pList.TypeName = "dbo.tvp_OneVarchar";
                        pList.Value = table;

                        cmd.Parameters.Add(pList);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var defualtWord = reader["InputValue"].ToString();
                                var variableWord = new VariableWord(defualtWord)
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    SingularValue = reader["SingularValue"].ToString(),
                                    PluralValue = reader["SingularValue"].ToString(),
                                    Definition = reader["Definition"].ToString()
                                };
                                variableWords.Add(variableWord);
                            }

                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    var s = new Synonym
                                    {
                                        WordId = Convert.ToInt32(reader["WordId"]),
                                        Id = Convert.ToInt32(reader["Id"]),
                                        Value = reader["Value"].ToString(),
                                        Similarity = Convert.ToInt32(reader["Similarity"]),
                                        Rank = Convert.ToInt32(reader["Rank"])
                                    };

                                    var variableWord = variableWords.FirstOrDefault(v => v.Id == s.WordId);
                                    if (variableWord != null)
                                    {
                                        variableWord.Synonyms.Add(s);
                                    }
                                }

                            }
                        }
                    }
                }
            }

            return variableWords;
        }

        public IEnumerable<Synonym> GetSynonyms(int wordId)
        {
            var variable = new Variable();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("stp_GetSynonyms", con) { CommandType = CommandType.StoredProcedure })
                {
                    var parameter = new SqlParameter("@WordId", SqlDbType.Int);
                    parameter.Value = wordId;

                    cmd.Parameters.Add(parameter);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var synonym = new Synonym
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Value = reader["Value"].ToString(),
                                WordId = reader["MatchWordId"] == DBNull.Value
                                            ? (int?)null
                                            : Convert.ToInt32(reader["MatchWordId"]),
                                Similarity = Convert.ToInt32(reader["Similarity"]),
                                Rank = Convert.ToInt32(reader["Rank"])
                            };
                            yield return synonym;
                        }
                    }

                }
            }
        }
    }
}
