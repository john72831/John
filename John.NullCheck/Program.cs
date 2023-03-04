var value = Random.Shared.Next(10) >= 5 ? new MySpecialClass("Test") : null;

//if (value == null) { }

#region C# 7

if (value is null) { }

if (value is object) { }

_ = value ?? throw new ArgumentNullException(nameof(value));

#endregion

#region C# 8

if (value is { }) { }

value ??= new MySpecialClass("Re new");

#endregion

#region C# 9

if (value is not null) { } 

#endregion





