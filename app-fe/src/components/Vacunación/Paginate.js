import React from "react";

function Paginate({ paginate, setPagina }) {
  console.log(paginate);

  const handlePageClick = (page) => {
    setPagina(page);
  };

  return (
    <nav aria-label="Page navigation example">
      <ul className="inline-flex -space-x-px">
        {[...Array(paginate)].map((_, index) => (
          <li key={index}>
            <button
              class="bg-white border border-gray-300 text-gray-500 hover:bg-gray-100 hover:text-gray-700 leading-tight py-2 px-3 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white"
              onClick={() => handlePageClick(index + 1)}
            >
              {index + 1}
            </button>
          </li>
        ))}
      </ul>
    </nav>
  );
}

export default Paginate;
