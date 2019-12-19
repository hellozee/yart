using System.Collections.Generic;
using System.Linq;

namespace yart
{
    public class Scene : IObject
    {
        private readonly List<IObject> _list;
        private Camera _cam;

        public Scene(List<IObject> objects)
        {
            _list = objects;
        }
        
        public Scene(List<IObject> objects, Camera cam)
        {
            _list = objects;
            _cam = cam;
        }

        public void SetCamera(Camera cam) => _cam = cam;
        
        public Camera GetCamera() => _cam;
        
        public bool Hit(Ray r, float tMin, float tMax, ref HitRecord record)
        {
            var tempRecord = new HitRecord();
            var hasHit = false;
            var closest = tMax;

            foreach (var dummy in _list
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