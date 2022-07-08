using Assignment3;

int[] numbers = WorkingWithMethods.GenerateNumber(10);
WorkingWithMethods.Reverse(numbers);
WorkingWithMethods.PrintNumbers(numbers);
Console.WriteLine(WorkingWithMethods.Fibonacci(8));

Cycle a = new Cycle();
ObjectOriented test = new ObjectOriented();
Console.WriteLine($"{test.X} {test.Y}");
Rectangle b = new Rectangle();
a.Center = test;
Console.WriteLine(b.Len);
a.area();
b.Len = 3;
b.area();




