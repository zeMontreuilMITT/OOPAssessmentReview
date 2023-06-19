using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessmentReview
{
    public class Post
    {
        private int _id;

        public int Id { get { return _id; } }   

        private User _user;
        private HashSet<Reaction> _reactions = new HashSet<Reaction>();

        public HashSet<Reaction> GetReactions() { return _reactions.ToHashSet(); }
        public void AddReaction(Reaction reaction)
        {
            _reactions.Add(reaction);
        }

        private string _body;
        private DateTime _dateOfCreation;

        public DateTime DateOfCreation { get { return _dateOfCreation; } }

        private static int s_maxBodyLength = 250;
        private static int s_minBodyLength = 10;

        public string Body { get { return _body; } }
        public void SetBody(string body)
        {
            if (body.Length < s_minBodyLength || body.Length > s_maxBodyLength)
            {
                throw new ArgumentOutOfRangeException(nameof(body), $"Body length must be between {s_minBodyLength} and {s_maxBodyLength} characters");
            }
        }

        public Post(int id, User user, string body)
        {
            _id = id;
            _user = user;
            SetBody(body);
            _dateOfCreation = DateTime.Now;
        }

    }
}
