﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace template_csharp_postgresql.Persistence.Repositories.FindStrategiesEntityB
{
    public class FindAll<EntityB> : IFindStrategy<EntityB>
    where EntityB : template_csharp_postgresql.Entities.EntityB, new()
    {
        public List<EntityB> find(NpgsqlConnection connection)
        {
            List<EntityB> entitiesB = new List<EntityB>();

            // 1) Execute query
            string query = "select * from entitiesB;";
            NpgsqlDataReader result;
            using (NpgsqlCommand executor = new NpgsqlCommand(query, connection))
            {
                result = executor.ExecuteReader();
            }

            // 2) Extract data
            while (result.Read())
            {
                System.Int32 id = result.GetInt32(0);
                string name = result.GetString(1);
                EntityB entityB = new EntityB();
                entityB.Id = id;
                entityB.Name = name;
                entitiesB.Add(entityB);
            }

            return entitiesB;
        }
    }
}
