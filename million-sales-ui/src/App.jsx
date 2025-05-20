import './App.css'
import { Routes, Route } from 'react-router-dom';
import ItemList from './components/PropertiesList';
import ItemDetail from './components/PropertyDetail';

function App() {

  return (
    <div style={{ padding: '2rem 2rem 0 2rem' }}>
      <h1>Propiedades Million</h1>
      <Routes>
        <Route path="/" element={<ItemList />} />
        <Route path="/detail/:id" element={<ItemDetail />} />
      </Routes>
    </div>
  );

}

export default App
