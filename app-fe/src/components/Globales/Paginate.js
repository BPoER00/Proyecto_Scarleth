import React from "react";

function Paginate({ paginate, setPagina, pagina }) {
  const handlePageClick = (page) => {
    setPagina(page);
  };

  return (
    <nav className="mt-3">
      <ul className="inline-flex -space-x-px">
        <li key={1}>
          <button
            className="bg-white border border-gray-300 text-gray-500 hover:bg-gray-100 hover:text-gray-700 ml-0 rounded-l-lg leading-tight py-2 px-3 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white"
            onClick={() => handlePageClick(1)}
          >
            Inicio
          </button>
        </li>
        {[...Array(paginate)].map((_, index) => {
          const isCurrent = index + 1 === pagina;
          if (
            index + 1 === pagina ||
            index + 1 === pagina + 1 ||
            index + 1 === pagina + 2 ||
            index + 1 === pagina - 1 ||
            index + 1 === pagina - 2
          ) {
            return (
              <li key={index}>
                <button
                  className={`bg-white border border-gray-300 text-gray-500 hover:bg-gray-100 hover:text-gray-700 leading-tight py-2 px-3 ${
                    isCurrent
                      ? "dark:bg-gray-400 dark:border-gray-500 dark:text-gray-950"
                      : "dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400"
                  } dark:hover:bg-gray-700 dark:hover:text-white`}
                  onClick={() => handlePageClick(index + 1)}
                >
                  {index + 1}
                </button>
              </li>
            );
          }
        })}
        <li key={paginate}>
          <button
            className="bg-white border border-gray-300 text-gray-500 hover:bg-gray-100 hover:text-gray-700 rounded-r-lg leading-tight py-2 px-3 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white"
            onClick={() => handlePageClick(paginate)}
          >
            Fin
          </button>
        </li>
      </ul>
    </nav>
  );
}

export default Paginate;
