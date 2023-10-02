"use client";
import { createContext, useContext } from "react";
import { getCuadros, getGrafica1, getGrafica2 } from "@/api/Dashboard.Api";

const DashboardContext = createContext();

export const useDashboard = () => {
  const context = useContext(DashboardContext);
  if (!context) throw new Error("useDashboard must used within a provider");
  return context;
};

function DashboardProvider({ children }) {
  const Cuadros = async () => {
    const cuadros = await getCuadros()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return cuadros;
  };

  const Grafica1 = async () => {
    const grafica = await getGrafica1()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return grafica;
  };

  const Grafica2 = async () => {
    const grafica = await getGrafica2()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return grafica;
  };

  return (
    <DashboardContext.Provider value={{ Cuadros, Grafica1, Grafica2 }}>
      {children}
    </DashboardContext.Provider>
  );
}

export default DashboardProvider;
