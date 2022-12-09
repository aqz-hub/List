namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemList<string> itemList = new ItemList<string>();

            itemList.AddFirst("data"); //добавляем голову
            Console.WriteLine(itemList.Head.Data);

            itemList.AddLast("data1"); //добавляем хвост
            Console.WriteLine(itemList.Tail.Data);

            var itemAfter = new Item<string>("data2");
            itemList.AddAfter(itemAfter, itemList.Head); //добавляем после головы
            Console.WriteLine(itemList.FirstOrDefault(x => x == itemAfter.Data));

            var itemBefore = new Item<string>("data3");
            itemList.AddBefore(itemBefore, itemList.Tail); //добавляем перед хвостом
            Console.WriteLine(itemList.FirstOrDefault(x => x == itemBefore.Data));
            Console.WriteLine(Environment.NewLine);

            itemList.Remove("data"); //удаляем элемент
            foreach(var item in itemList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Environment.NewLine);

            itemList.RemoveHead(); //удаляем голову
            foreach (var item in itemList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Environment.NewLine);

            itemList.RemoveTail(); //удаляем хвост
            foreach (var item in itemList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}