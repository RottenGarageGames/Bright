using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace ItemRepository.Interface
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        [SerializeField] string id;
        public string ID { get { return id; } }
        public string Name;
        public Sprite Icon;

        [Range(1,99)]
        public int MaximumStacks = 1;

        private void OnValidate()
        {
            string path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(path);
        }
        public virtual Item GetCopy()
        {
            return this;
        }
        public virtual void Destroy()
        {

        }
    }
}
