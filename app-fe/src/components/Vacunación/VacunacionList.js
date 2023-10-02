import { useState, useEffect } from "react";
import CardComponentsAll from "../Contenedores/CardComponentsAll.js";
import LoadingBar from "../Inputs/LoadingBar.js";
import TableData from "../Globales/TableData.js";
import ContenidoTabla from "./ContenidoTabla";
import { useVacunacion } from "@/context/Vacunacion.Context.js";
import Paginate from "../Globales/Paginate.js";
import Filtros from "./Filtros.js";

function VacunacionList() {
  const { Vacunacion } = useVacunacion();
  const [data, setData] = useState([]);
  const [paginate, setPaginate] = useState(1);
  const [filtro, setFiltros] = useState({
    personaId: "0",
    fechaInicioValue: "",
    fechaFinValue: "",
    vacunaId: "0",
  });

  useEffect(() => {
    info(filtro);
  }, [filtro, paginate]);

  const info = async () => {
    setData(await Vacunacion(paginate, filtro));
  };

  const cabeceras = [
    "Descripcion",
    "Persona",
    "Dosis",
    "Vacuna",
    "Proceso",
    "Opciones",
  ];
  if (data.length === 0) {
    return (
      <>
        <CardComponentsAll>
          <div className="w-full max-h-[55vh] overflow-auto">
            <div className="flex items-center justify-center">
              <div className="col-span-12">
                <div className="lg:overflow-visible">
                  <p>No se encontraron datos</p>
                </div>
              </div>
            </div>
          </div>
        </CardComponentsAll>
      </>
    );
  }

  return (
    <CardComponentsAll>
      <div className="w-full">
        {data.length === 0 ? (
          <LoadingBar />
        ) : (
          <>
            <Filtros setFiltros={setFiltros} />

            <div className="max-h-[75vh] overflow-x-auto overflow-visible">
              <TableData cabecera={cabeceras}>
                <ContenidoTabla data={data.records.data} />
              </TableData>
            </div>
          </>
        )}
      </div>
      <Paginate
        paginate={data.pages}
        setPagina={setPaginate}
        pagina={paginate}
      />
    </CardComponentsAll>
  );
}

export default VacunacionList;
