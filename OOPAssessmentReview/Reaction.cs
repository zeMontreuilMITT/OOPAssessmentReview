using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessmentReview
{
    public class Reaction
    {
        private int _id;
        public int Id { get { return _id; } }   
        private Post _post;
        private User _user;
        
        public Post Post { get { return _post; } }
        public User User { get { return _user; } }

        private bool _isPositive;
        public bool IsPositive { get { return _isPositive; } }

        public void SetReaction(bool isPositive)
        {
            _isPositive = isPositive;
        }

        public Reaction(int id, User user, Post post, bool isPositive)
        {
            _id = id;
            _post = post;
            _user = user;
            _isPositive = isPositive;
        }
    }
}
