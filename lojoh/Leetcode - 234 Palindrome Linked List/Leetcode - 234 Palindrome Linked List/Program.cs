using Leetcode___234_Palindrome_Linked_List;

bool IsPalindrome1(ListNode head)
{
    Stack<int> stack = new();
    Queue<int> queue = new();

    while (head != null)
    {
        stack.Push(head.val);
        queue.Enqueue(head.val);
        head = head.next;
    }

    int count = queue.Count;
    while (queue.Count > count / 2)
    {
        if (stack.Pop() != queue.Dequeue())
        {
            return false;
        }
    }

    return true;
}

bool IsPalindrome2(ListNode head)
{
    var list = new List<int>();
    var node = head;
    while (node != null)
    {
        list.Add(node.val);
        node = node.next;
    }

    var count = list.Count;
    for (int i = 0; i < count / 2; i++)
        if (list[i] != list[count - i - 1])
            return false;

    return true;
}

ListNode DeepCopy(ListNode node)
{
    if (node == null)
        return null;

    return new ListNode()
    {
        val = node.val,
        next = DeepCopy(node.next)
    };
}
bool JoelIsPalindrome(ListNode head)
{
    int listNodeLength = 0;
    ListNode headNode = DeepCopy(head);
    ListNode runner1 = DeepCopy(head);
    ListNode runner2 = DeepCopy(head);

    // Count length of LinkedList
    while (runner1 != null)
    {
        runner1 = runner1.next;
        listNodeLength++;
    }

    // Make a reversed version of LinkedList
    ListNode prev = null;
    while (runner2 != null)
    {
        ListNode next_node = runner2.next;
        runner2.next = prev;
        prev = runner2;
        runner2 = next_node;
    }

    int count = listNodeLength;
    while (count > listNodeLength / 2)
    {
        if (headNode.val != prev.val)
        {
            return false;
        }
        headNode = headNode.next;
        prev = prev.next;

        count--;
    }
    return true;
}


// TESTDATA BELOW
ListNode head0 = new ListNode(
    1,
    new ListNode(
        2,
        new ListNode(
            3,
            new ListNode(
                4,
                null))));

ListNode head1 = new ListNode(
    0,
    new ListNode(
        1,
        new ListNode(
            1,
            new ListNode(
                0,
                null))));

ListNode head2 = new ListNode(
    0,
    new ListNode(
        1,
        new ListNode(
            1,
            new ListNode(
                1,
                null))));



Console.WriteLine("=== IsPalindrome1 ===");
Console.WriteLine("| Time Complexity: O(1.5n)");
Console.WriteLine("| Space Complexity: O(2n)");
Console.WriteLine("=====================");
Console.WriteLine(IsPalindrome1(head0));
Console.WriteLine(IsPalindrome1(head1));
Console.WriteLine(IsPalindrome1(head2));

Console.WriteLine();
Console.WriteLine("=== IsPalindrome2 ===");
Console.WriteLine("| Time Complexity: O(1.5n)");
Console.WriteLine("| Space Complexity: O(n)");
Console.WriteLine("=====================");
Console.WriteLine(IsPalindrome2(head0));
Console.WriteLine(IsPalindrome2(head1));
Console.WriteLine(IsPalindrome2(head2));

Console.WriteLine();
Console.WriteLine("=== JoelIsPalindrome ===");
Console.WriteLine("| Time Complexity: O(?)");
Console.WriteLine("| Space Complexity: O(?)");
Console.WriteLine("=====================");
Console.WriteLine(JoelIsPalindrome(head0));
Console.WriteLine(JoelIsPalindrome(head1));
Console.WriteLine(JoelIsPalindrome(head2));




