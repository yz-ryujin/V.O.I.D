# V.O.I.D — Veil of Infinite Dark

</br>

> *“Where light breaks, darkness blooms.”*

</br>

**Veil of Infinite Dark** é um projeto RPG 2D *side-scroller* de combate ambientado em um universo consumido por um vazio eterno e ameaças sombrias ocultas. Este repositório reúne as mecânicas, narrativa, sistemas e arte do jogo em desenvolvimento.

</br>

<div align="center">
  <img src="https://github.com/yz-ryujin/V.O.I.D/blob/dev/Assets/Images/logo.png" alt="VOID Logo" width="1080" />
</div>

</br>

<hr style="width:40%; margin: 16px auto; border: 1px solid #555;" />


## 🧠 Visão Geral

| Atributo     | Detalhes                                   |
|:-------------|:-------------------------------------------|
| Plataforma   | C# (.NET Console – Protótipo)              |
| Gênero       | RPG 2D Side-Scroller (Dark Fantasy)        |
| Status       | Em desenvolvimento                         |
| Estilo       | Minimalista, gótico, atmosférico           |
| Inspirações  | Hollow Knight, Blasphemous, Dead Cells     |



---


## 🕹️ Mecânicas-Chave

- 🗡️ **Combate lateral em tempo real**
- 🕳️ **Sistema de sanidade e influência do vazio**
- 🌀 **Habilidades abissais e corrupção**
- 👁️ **Narrativa fragmentada através de ecos, visões e entidades**
- 🏛️ **Fases conectadas por um mundo em ruínas**

---


## 🗂️ Estrutura do Projeto

```bash
V.O.I.D/

├── Core/            # Loop principal, gerenciamento de cenas e entrada
├── Entities/        # Personagens, inimigos, NPCs e atributos
├── Systems/         # Combate, história, save/load
├── UI/              # HUD e menus no console
├── Utils/           # Funções auxiliares
├── Program.cs       # Ponto de entrada (main)
└── V.O.I.D.csproj   # Arquivo do projeto .NET
````

---

## 🛠️ Requisitos

* [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
* Terminal (Bash, CMD ou PowerShell)
* Editor de código (VS Code, Rider, Visual Studio, etc.)

---

## 🚀 Como Rodar

```bash
# Clone o projeto
git clone https://github.com/yz-ryujin/V.O.I.D
cd V.O.I.D

# Inicialize o projeto (se ainda não tiver criado)
dotnet new console --output ./

# Rode o jogo no console
dotnet run
```

---

## 🔮 Próximos Objetivos

* [ ] Implementar loop de combate com ataques e animações via console
* [ ] Criar a lógica de sanidade/corrupção
* [ ] Construir o primeiro boss e evento narrativo
* [ ] Prototipar movimentação lateral completa
* [ ] Migrar futuramente para motor gráfico (Unity, Godot, Monogame)
* [ ] Adicionar suporte a Spectre.Console para HUD imersiva

---

## 📜 Licença

Este projeto está licenciado sob a [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0).

Você é livre para usar, modificar, distribuir e contribuir, desde que mantenha os avisos de copyright e licença original.

---

## 💀 O Vazio te Observa

> *"He who listens long enough... becomes the echo."*
> — Fragmento de códice perdido


