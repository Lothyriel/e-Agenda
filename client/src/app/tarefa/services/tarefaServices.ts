import { Injectable } from '@angular/core';
import { ArgumentOutOfRangeError } from 'rxjs';
import { Prioridade, Tarefa } from 'src/app/shared/model/Tarefa';

@Injectable({
  providedIn: 'root'
})
export class TarefaService {

  constructor() { }

  public adicionarTarefa(tarefa: Tarefa) {
    console.log(tarefa);

    let tarefas = this.obterTarefas()
    let id = Number(localStorage.getItem("IdTarefa"))
    id++
    tarefa.id = id;
    tarefas.push(tarefa)

    this.Salvar(id, tarefas);
  }

  private Salvar(id: number, tarefas: Tarefa[]) {
    localStorage.setItem("IdTarefa", id.toString());
    localStorage.setItem("tarefas",JSON.stringify(tarefas));
  }

  public obterTarefa(tarefaId: number): Tarefa {
    let tarefa = this.obterTarefas().find(t => t.id === tarefaId)
    if (!tarefa)
      throw new Error()

    return tarefa
  }

  public atualizarTarefa(tarefa: Tarefa) {
    let tarefas = this.obterTarefas()
    let index = tarefas.indexOf(tarefa)
    
    tarefa.id = tarefas[index].id
    tarefas[index] = tarefa

    this.Salvar(tarefa.id, tarefas)
  }

  public obterTarefas(): Tarefa[] {
    let tarefasKey = localStorage.getItem("tarefas")
    if (!tarefasKey)
      return []

    let tarefas: Tarefa[] = JSON.parse(tarefasKey) 
    return tarefas;
  }
}