import React, { useState } from 'react';
import './App.css';
import Header from './components/Header';
import Body from './components/Body';

function App() {
    const [categoryId, setcategoryId] = useState(null);
    const [subCategoryId, setsubCategoryId] = useState(null);
    const [blogId, setBlogId] = useState(null);
    const [subCategories, setSubCategories] = useState([]);
    const [token, setToken] = useState(null);


  return (
    <div className="App">
          <Header setcategoryId={setcategoryId} setsubCategoryId={setsubCategoryId} setBlogId={setBlogId} subCategories={subCategories} setSubCategories={setSubCategories} />
          <Body categoryId={categoryId} subCategoryId={subCategoryId} setBlogId={setBlogId} blogId={blogId} setcategoryId={setcategoryId} setsubCategoryId={setsubCategoryId} subCategories={subCategories} setSubCategories={setSubCategories} />
    </div>
  );
}

export default App;
