using Scripts.Abstracts;
using Scripts.Interfaces;
using System.Collections.Generic;

namespace Scripts.Models.Physics.Managers
{
    class PhysicalObjectManager : Singleton<PhysicalObjectManager>, IRepository<PhysicalObject>
    {
        private readonly List<PhysicalObject> _existPhysicalObject = new List<PhysicalObject>();
        public void Add(PhysicalObject value) => _existPhysicalObject.Add(value);

        public void Remove(PhysicalObject value) => _existPhysicalObject.Remove(value);

        public IEnumerable<PhysicalObject> GetAll() => _existPhysicalObject;
    }
}
