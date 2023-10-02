"use client";
import { useEffect, useState } from "react";

import CardInfoComponentDashboard from "./CardInfoComponentDashboard";
import CardMidComponentDashboard from "./CardMidComponentDashboard";
import CardFootComponentDashboard from "./CardFootComponentDashboard";

import { useDashboard } from "@/context/Dashboard.Context";

function InfoDashboard() {
  const { Cuadros, Grafica1, Grafica2 } = useDashboard();

  const [data, setData] = useState([]);
  const [grap1, setGrap1] = useState([]);
  const [grap2, setGrap2] = useState([]);

  useEffect(() => {
    info();
  }, []);

  const info = async () => {
    setData(await Cuadros());
    setGrap1(await Grafica1());
    setGrap2(await Grafica2());
  };

  const vacunacionHoy = data.vacunacionHoy > 0 ? data.vacunacionHoy : "0";
  const vacunacionInventario =
    data.vacunasInventario > 0 ? data.vacunasInventario : "0";
  const asignacionesActivas =
    data.asignacionesActivas > 0 ? data.asignacionesActivas : "0";
  const vacunacionTotal = data.vacunacionTotal > 0 ? data.vacunacionTotal : "0";

  return (
    <>
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 p-4 gap-4">
        <CardInfoComponentDashboard
          name={"Vacunas Del Dia"}
          value={vacunacionHoy}
        />
        <CardInfoComponentDashboard
          name={"Vacunas en inventario"}
          value={vacunacionInventario}
        />
        <CardInfoComponentDashboard
          name={"Medicos Activos"}
          value={asignacionesActivas}
        />
        <CardInfoComponentDashboard
          name={"Vacunacion Total"}
          value={vacunacionTotal}
        />
      </div>
      <div className="grid grid-cols-1 lg:grid-cols-2 p-4 gap-4">
        <CardMidComponentDashboard
          nombre={"Vacunas En Inventario"}
          data={grap1}
        />
        <CardMidComponentDashboard nombre={"Vacunas Del Dia"} data={grap2} />
      </div>

      <div className="mt-8 mx-4">
        <CardFootComponentDashboard />
      </div>
    </>
  );
}

export default InfoDashboard;
