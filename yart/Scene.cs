using System.Collections.Generic;
using System.Linq;

namespace yart
{
    public class Scene : IObject
    {
        private readonly List<IObject> _list;

        public Scene(List<IObject> objects)
        {
            _list = objects;
        }
        
        public bool Hit(Ray r, double tMin, double tMax, ref HitRecord record)
        {
            var tempRecord = new HitRecord();
            var hasHit = false;
            var closest = tMax;

            foreach (var item in _list
                .Where(item => item.Hit(r, tMin, closest, ref tempRecord)))
            {
                hasHit = true;
                closest = tempRecord.T;
                record = tempRecord;
            }
            
            return hasHit;
        }
    }
}