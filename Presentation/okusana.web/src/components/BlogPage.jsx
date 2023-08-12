import React from 'react';
import sha256 from 'crypto-js/sha256';

function BlogPage({ blogId }) {
    console.log("blog sayfası");
  return (
      <p>{ blogId } idli blog</p>
  );
}

export default BlogPage;