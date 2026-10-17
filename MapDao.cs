namespace BaoHiem.DAO;

/// <summary>DAO nhóm "danh mục" (KhachHang, LoaiBaoHiem, NhanVien): Dictionary theo khóa chính, tra cứu O(1).</summary>
public class MapDao<T> : IDao<T> where T : class
{
    protected readonly Dictionary<string, T> Map = new();
    private readonly Func<T, string> _key;

    public MapDao(Func<T, string> key) { _key = key; }

    public IEnumerable<T> GetAll() => Map.Values.OrderBy(_key);
    public T? GetById(string id) => Map.TryGetValue(id, out var v) ? v : null;
    public bool Add(T item) => Map.TryAdd(_key(item), item);
    public bool Update(string id, T item)
    {
        if (!Map.ContainsKey(id) || _key(item) != id) return false;
        Map[id] = item; return true;
    }
    public bool Delete(string id) => Map.Remove(id);
}
