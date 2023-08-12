import React from 'react';
import sha256 from 'crypto-js/sha256';

function BlogPage({ blog }) {
    console.log("blog sayfası");
  return (
      <p>{ blog.title}</p>
  );
}

export default BlogPage;