
namespace ArtFolio;
internal class StudenteEntity
{
	private int id;

	public int getID() {  return id; }
	public void setID(int id) { this.id = id; }

	public StudenteEntity() { instance = this; }

	private static StudenteEntity? instance = null;

	public static StudenteEntity get() {
		return instance ?? new StudenteEntity();
	}
}

