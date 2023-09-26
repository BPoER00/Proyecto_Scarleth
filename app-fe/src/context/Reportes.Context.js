"use client";
import { createContext, useContext, useState } from "react";

const ReportesContext = createContext();

export const useReportes = () => {
  const context = useContext(ReportesContext);
  if (!context) throw new Error("useReportes must used within a provider");
  return context;
};

function ReportesProvider({ children }) {

  return (
    <ReportesContext.Provider value={{}}>
      {children}
    </ReportesContext.Provider>
  );
}

export default ReportesProvider;
