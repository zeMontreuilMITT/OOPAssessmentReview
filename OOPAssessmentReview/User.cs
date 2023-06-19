using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessmentReview
{
    public class User
    {
        private int _id;
        public int Id { get { return _id; } }  

        private HashSet<Post> _posts = new HashSet<Post>();
        private HashSet<Reaction> _reactions = new HashSet<Reaction>();
        private string _userName;
        private int _age;

        public string UserName
        {
            get
            {
                return _userName;
            }
        }

        public void SetAge(int age)
        {
            if (age < 0) {
                throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be a negative value.");
            }

            _age = age;
        }

        public void SetUserName(string userName)
        {
            if(!(userName.Length >= 3) || !(userName.Length <= 20))
            {
                throw new ArgumentOutOfRangeException(nameof(userName), "UserName must be 3 to 20 characters in length");
            } else
            {
                // stack overflow suggestion for validating alphanumeric input
                // https://stackoverflow.com/a/26576066
                if (userName.Any(ch => !char.IsLetterOrDigit(ch))) {
                    throw new ArgumentOutOfRangeException(nameof(userName), "UserName may only contain letters and numbers");
                }
            }

            _userName = userName;
        }

        public void AddPost(Post post)
        {
            _posts.Add(post);
        }
        public HashSet<Post> GetPosts()
        {   
            //return copy of Posts lists, rather than user's post list
            return _posts.ToHashSet();
        }

        public void AddReaction(Reaction reaction)
        {
            _reactions.Add(reaction);
        }

        public HashSet<Reaction> GetReactions()
        {
            return _reactions.ToHashSet();
        }

        public User(int id, string userName, int age)
        {
            _id = id;
            SetUserName(userName);
            SetAge(age);
        }
    }
}
