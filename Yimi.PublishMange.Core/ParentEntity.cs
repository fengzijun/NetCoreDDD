using MongoDB.Bson;
using System;

namespace Yimi.PublishManage.Core
{
    public abstract class ParentEntity
    {
        public ParentEntity()
        {
            _id = ObjectId.GenerateNewId().ToString();
        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _id = ObjectId.GenerateNewId().ToString();
                else
                    _id = value;
            }
        }

        private string _id;

        public bool Deleted { get; set; }

        public DateTime Createtime { get; set; }
        public DateTime Updatetime { get; set; }

    }
}
