namespace Practice7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = "comments.json";
            string binPath = "comments.bin";

            Comments comments = SaveLoad.LoadJson(jsonPath);
            Comments comments2 = SaveLoad.BinLoad(binPath);
            Console.WriteLine("From json file");
            Console.WriteLine(comments);
            Console.WriteLine("From binary file");
            Console.WriteLine(comments2);



            int act;

            bool correct = false;
            while (!correct)
            {
                Console.WriteLine("Если хотите добавить комментарий введите 1, чтобы удалить введите 2, чтобы выйти из приложения введите 3");
                try
                {
                    act = Convert.ToInt32(Console.ReadLine());
                    if (act == 1) 
                    {
                        Console.WriteLine("Введите комментарий, который хотите добавить");
                        string comment = Console.ReadLine();
                        if (comment is not null && comment.Length != 0)
                        {
                            comments.AddComment(comment);
                            SaveLoad.SaveJson(jsonPath, comments.GetAllComments());
                            SaveLoad.SaveBin(binPath, comments.GetAllComments());
                            Console.WriteLine(comments);

                        } else
                        {
                            Console.WriteLine("Вы не можете добавлять пустой комментарий");
                        }

                    } else if (act == 2)
                    {
                        if (comments.GetAllComments().Count == 0)
                        {
                            Console.WriteLine("Нет комментариев, которые можна удалить");
                        } else
                        {
                            bool correctIndex = false;
                            while (!correctIndex)
                            {
                                Console.WriteLine("Введите номер комментария, который хотите удалить");
                                try
                                {
                                    int index = Convert.ToInt32(Console.ReadLine());
                                    if (index <= 0 && index > comments.GetAllComments().Count)
                                    {
                                        Console.WriteLine("Что-то пошло не так");
                                        correctIndex = false;
                                    }
                                    else
                                    {
                                        comments.RemoveComment(index);
                                        SaveLoad.SaveJson(jsonPath, comments.GetAllComments());
                                        SaveLoad.SaveBin(binPath, comments.GetAllComments());
                                        Console.WriteLine(comments);
                                        correctIndex = true;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Неверный формат");
                                    correctIndex = false;
                                }
                            }
                        }
                    } else if (act == 3)
                    {
                        break;
                    } else
                    {
                        Console.WriteLine("Были указаны неверные цифры");
                    }
                }
                catch
                {
                    Console.WriteLine("Что-то не так");
                    correct = false;
                }
            }

        }
    }
}