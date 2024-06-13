using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 2_CleanCode
{
    public class Triangle
    {
        int a, b, c;

        private Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public static Triangle FromInt(List<int> sides) => new Triangle(a, b, c);

        public static FromMongoDB(IMongoDatabase database) => new ItemsRepository(database.GetCollection<Item>(collectionName));
        {
            new ItemsRepository(database.GetCollection<Item>(collectionName));
        }
    }
}