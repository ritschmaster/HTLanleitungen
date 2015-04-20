//Entität
@Entity //JPA-Schlüsselwort für gemappte Entitiy
@NamedQuery(name="Pupil.findAll", query="SELECT p FROM Pupil p")
//vorgefertigte Query, die mit Pupil.findAll global erreichbar ist
public class Pupil implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY) //Gültige Primärschlüssel erstellen
	private int pupilId;
	private int catalogueNo;
	private String firstname;
	private String lastname;
	private String pupilNo;

	//bi-directional many-to-one association to Schoolclass
	@ManyToOne
	@JoinColumn(name="classId") //Die 1-n Beziehung zu einer Klasse
	private Schoolclass schoolclass;
	
	//Getter und Setter
	....
}

//DAO
@Named
@Stateless //nur einen Methodenaufruf lang gültig
public class PupilDAO { 
	@PersistenceContext
	private EntityManager em; //Bindeglied zwischen DB und Java

	public void create(Pupil p) {
		em.persist(p); //.persist wird vom EM in SQL - Create umgewandelt
	}
	public void delete(Pupil p) {
		em.remove(em.contains(p) ? p : get(p.getClassId()));
	} 
	public void update(Pupil p) {
		em.merge(p);
	} 
	public List<Pupil> get() {
		return em.createNamedQuery("Pupil.findAll",Pupil.class).getResultList();
	}
	//weitere Aufrufe
	....
}