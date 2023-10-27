using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    internal class Comments
    {
        private List<string> comments;

        /// <summary>
        /// Используется коллекция List<string> для хранения комментариев. 
        /// Это было выбрано из-за своей простоты и эффективности для этой задачи. 
        /// Она позволяет легко добавлять, удалять и получать комментарии.
        /// </summary>

        /// <summary>
        /// Creating of empty list
        /// </summary>
        public Comments()
        {
            comments = new List<string>();
        }

        /// <summary>
        /// Adding of comment in List of comments 
        /// </summary>
        public void AddComment(string comment)
        {
            comments.Add(comment);
        }

        /// <summary>
        /// Removing of comment from List of comments 
        /// </summary>
        public void RemoveComment(int index)
        {
            comments.RemoveAt(index - 1);
        }

        /// <summary>
        /// Getting List of comments 
        /// </summary>

        public List<string> GetAllComments()
        {
            return comments;
        }

        public override string ToString()
        {
            string allComments = "";
            int i = 1;
            if (GetAllComments().Count == 0)
            {
                allComments += "Пока нет комментариев";
            } else
            {
                foreach (string comment in GetAllComments())
                {
                    allComments += $"{i}. " + comment + "\n";
                    i++;
                }
            }
            return allComments;
        }
    }
}
