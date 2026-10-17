namespace BaoHiem.DAO;

/// <summary>
/// DAO nhóm "giao dịch": List làm cấu trúc chính (duyệt toàn bộ để tổng hợp),
/// kèm Dictionary phụ gom theo khóa ngoại (tùy chọn) để join ngược nhanh.
/// </summary>
public class ListDao<T> : IDao<T> where T : class
{
    protected readonly List<T> Items = new();
    private readonly Func<T, string> _key;
    private readonly Func<T, string>? _groupKey;
    private Dictionary<string, List<T>> _groups = new();

    public ListDao(Func<T, string> key, Func<T, string>? groupKey = null)
    {
        _key = key; _groupKey = groupKey;
    }

    public IEnumerable<T> GetAll() => Items;
    public T? GetById(string id) => Items.FirstOrDefault(x => _key(x) == id);

    public bool Add(T item)
    {
        if (GetById(_key(item)) != null) return false;
        Items.Add(item); Rebuild(); return true;
    }
    public bool Update(string id, T item)
    {
        int i = Items.FindIndex(x => _key(x) == id);
        if (i < 0 || _key(item) != id) return false;
        Items[i] = item; Rebuild(); return true;
    }
    public bool Delete(string id)
    {
        bool ok = Items.RemoveAll(x => _key(x) == id) > 0;
        if (ok) Rebuild();
        return ok;
    }

    /// <summary>Lấy các phần tử theo khóa ngoại đã gom sẵn (rỗng nếu không có).</summary>
    public IReadOnlyList<T> GetByGroup(string groupKey) =>
        _groups.TryGetValue(groupKey, out var l) ? l : Array.Empty<T>();

    private void Rebuild()
    {
        if (_groupKey == null) return;
        _groups = Items.GroupBy(_groupKey).ToDictionary(g => g.Key, g => g.ToList());
    }
}
