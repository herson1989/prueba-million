import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import './PropertyDetail.css';

export default function ItemDetail() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [item, setItem] = useState(null);

  useEffect(() => {
    fetch(`http://localhost:5177/api/Properties/${id}`)
    .then(async res => {
        if (!res.ok) {
        const errorText = await res.text();
        throw new Error(errorText);
        }
        return res.json();
    })
    .then(data => setItem(data))
    .catch(err => console.error('Error al cargar detalle:', err.message));
  }, [id]);

  if (!item) return <p>Cargando detalle...</p>;

  return (
        <div>
            <h2>Propietario</h2>
            <p>Nombre: {item.owner.name}</p>
            <p>Dirección: {item.owner.address}</p>
            <p>Fecha de cumpleaños: {item.owner.birthday.split('T')[0].split('-').reverse().join('/')}</p>

            <h2>Imágenes</h2>
            <div>
            {item.images
                .filter((img) => img.enabled)
                .map((img) => (
                <img
                    key={img.id}
                    src={img.file}
                    alt="Imagen de propiedad"
                    className='property-image'
                />
                ))}
            </div>

            <button onClick={() => navigate(-1)}>Volver</button>
        </div>
    );
}