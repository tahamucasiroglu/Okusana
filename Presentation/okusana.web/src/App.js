import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import Header from './components/Header';
import MainPage from './components/MainPage';
import Body from './components/Body';
import Page404 from './components/Page404';

function App() {
    const [categoryId, setcategoryId] = useState(null);
    const [subCategoryId, setsubCategoryId] = useState(null);
    const [blogId, setBlogId] = useState(null);







  return (
    <div className="App">
          <Header setcategoryId={setcategoryId} setsubCategoryId={setsubCategoryId} setBlogId={setBlogId} />
          <Body categoryId={categoryId} subCategoryId={subCategoryId} setBlogId={setBlogId} blogId={blogId} setcategoryId={setcategoryId} setsubCategoryId={setsubCategoryId} />
          {/*<Page404/>*/}
    </div>
  );
}

export default App;
