﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using template_csharp_postgresql.Persistence.Repositories.FindStrategiesEntityA;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using template_csharp_postgresql.Entities;

namespace template_csharp_postgresql.Persistence.Repositories.FindStrategiesEntityA.Tests
{
    [TestClass()]
    public class FindAllTests
    {
        private string connectionString =
            "Server = " + Globals.SERVER +
            "; User Id = " + Globals.USER_ID +
            "; Password = " + Globals.PASSWORD +
            "; Database = " + Globals.DATABASE_NAME;

        [TestMethod()]
        public void findTest()
        {

            NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
            connection.Open();
            FindAllEntitiesA<EntityA> findAll = new FindAllEntitiesA<EntityA>();
            List<EntityA> entitiesA = findAll.find(connection);
            connection.Close();
            if (entitiesA.Count == 0)
            {
                Assert.Fail();
            }

        }
    }
}