import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './PropertiesList.css';

export default function PropertiesList() {

  const [properties, setProperties] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  //Filtros
  const [nameFilter, setNameFilter] = useState('');
  const [addressFilter, setAddressFilter] = useState('');
  const [minPrice, setMinPrice] = useState('');
  const [maxPrice, setMaxPrice] = useState('');

  const filteredProperties = properties.filter((property) => {
    const nameMatch = property.name.toLowerCase().includes(nameFilter.toLowerCase());
    const addressMatch = property.address.toLowerCase().includes(addressFilter.toLowerCase());
    const min = minPrice === '' ? 0 : parseFloat(minPrice);
    const max = maxPrice === '' ? Number.MAX_SAFE_INTEGER : parseFloat(maxPrice);
    const priceMatch = property.price >= min && property.price <= max;
    return nameMatch && addressMatch && priceMatch;
  });

  useEffect(() => {
    setLoading(true);
    fetch('http://localhost:5177/api/Properties')
        .then(res => res.json())
        .then(data => {
          setProperties(data.properties);
        })
        .catch(err => console.error(err))
        .finally(() => setLoading(false));
  }, []);

  const seeDetail = (id) => {
    navigate(`/detail/${id}`);
  };

  return (
    <div>
      <h2>Listado de propiedades</h2>

      <div className="filters">
        <input placeholder="Filtro por nombre" value={nameFilter} onChange={(e) => setNameFilter(e.target.value)} />
        <input placeholder="Filtro por dirección" value={addressFilter} onChange={(e) => setAddressFilter(e.target.value)} />
        <input type="number" placeholder="Precio mínimo" value={minPrice} onChange={(e) => setMinPrice(e.target.value)} />
        <input type="number" placeholder="Precio máximo" value={maxPrice} onChange={(e) => setMaxPrice(e.target.value)} />
      </div>

      {loading ? (
        <p>Cargando propiedades...</p>
      ) : (
        <ul className='property-ul'>
          {filteredProperties.map(item => (
            <li key={item.id} className='property-item'>
              <p>Nombre: {item.name}</p>
              <p>Dirección: {item.address}</p>
              <p>Precio: ${item.price.toLocaleString()}</p>
              <p>Código Interno: {item.codeInternal}</p>
              <p>Año: {item.year}</p>
              <button onClick={() => seeDetail(item.id)} className='detail-button'>
                Ver detalle
              </button>
            </li>
          ))}
        </ul>
      )}
    </div>
  );

}