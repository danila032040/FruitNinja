using Scripts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PhysicalObjectManager : Singleton<PhysicalObjectManager>, IRepository<PhysicalObject>
{
    private readonly List<PhysicalObject> _existPhysicalObject = new List<PhysicalObject>();
    public void Add(PhysicalObject value) => _existPhysicalObject.Add(value);

    public void Remove(PhysicalObject value) => _existPhysicalObject.Remove(value);

    public IEnumerable<PhysicalObject> GetAll() => _existPhysicalObject;
}
