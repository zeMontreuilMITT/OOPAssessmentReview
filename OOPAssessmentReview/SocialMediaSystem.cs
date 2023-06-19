using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessmentReview
{
    public static class SocialMediaSystem
    {
        private static int s_idSeed = 1;
        private static HashSet<Reaction> s_reactions = new HashSet<Reaction>();
        private static HashSet<Post> s_posts = new HashSet<Post>();
        private static HashSet<User> s_users = new HashSet<User>();

        public static User? CreateUser(string userName, int age)
        {
            try
            {
                User newUser = new User(s_idSeed, userName, age);
                s_idSeed++;
                s_users.Add(newUser);
                return newUser;
            } catch (Exception ex)
            {
                Console.WriteLine($"Unable to create new user: {ex.Message}");
                return default;
            }
        }
        public static Post? CreatePost(User user, string body)
        {
            try
            {
                Post newPost = new Post(s_idSeed, user, body);
                s_posts.Add(newPost);
                s_idSeed++;
                user.AddPost(newPost);
                return newPost;
            } catch (Exception ex) {
                Console.WriteLine($"Unable to create new Post: {ex.Message}");
                return default;
            }
        }

        public static Reaction? AddReaction(User user, Post post, bool isPositive)
        {
            Reaction? reaction = user.GetReactions().FirstOrDefault(r => r.Post == post);

            if(reaction != null) {
                reaction.SetReaction(isPositive);
                return reaction;
            } else
            {
                Reaction newReaction = new Reaction(s_idSeed, user, post, isPositive);
                user.AddReaction(newReaction);
                post.AddReaction(newReaction);
                s_reactions.Add(newReaction);  
                return newReaction;
            }
        }
    }
}
