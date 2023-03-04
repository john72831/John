var guid = Guid.NewGuid();
//By explicit operator
UserId userId = (UserId)guid;
//By implicit operator
guid = userId;

class UserId
{
    public Guid Id { get; set; }

    public UserId(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// 明確轉換
    /// </summary>
    public static explicit operator UserId(Guid id)
    {
        return new UserId(id);
    }

    /// <summary>
    /// 隱含轉換
    /// </summary>
    public static implicit operator Guid(UserId userId)
    {
        return userId.Id;
    }
}