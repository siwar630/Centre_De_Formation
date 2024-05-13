using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Centre_de_formation.Models;

namespace Centre_de_formation.Controllers
{
    public class SessionsController : Controller
    {
        private readonly CentreFormationContext _context;

        public SessionsController(CentreFormationContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var centreFormationContext = _context.Sessions.Include(s => s.Formateur).Include(s => s.Formation).Include(s => s.Salle);
            return View(await centreFormationContext.ToListAsync());
        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .Include(s => s.Formateur)
                .Include(s => s.Formation)
                .Include(s => s.Salle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // GET: Sessions/Create
        public IActionResult Create()
        {
            ViewData["Formateur"] = new SelectList(_context.Formateurs, "Id", "Nom");
            ViewData["Formation"] = new SelectList(_context.Formations, "Id", "NomFormation");
            ViewData["Salle"] = new SelectList(_context.Salles, "Id", "NumSalle");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,duree,dateDebut,SalleId,FormateurId,FormationId")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormateurId"] = new SelectList(_context.Formateurs, "Id", "Id", session.FormateurId);
            ViewData["FormationId"] = new SelectList(_context.Formations, "Id", "Id", session.FormationId);
            ViewData["SalleId"] = new SelectList(_context.Salles, "Id", "Id", session.SalleId);
            
            return View(session);
        }

        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            ViewData["FormateurId"] = new SelectList(_context.Formateurs, "Id", "Id", session.FormateurId);
            ViewData["FormationId"] = new SelectList(_context.Formations, "Id", "Id", session.FormationId);
            ViewData["SalleId"] = new SelectList(_context.Salles, "Id", "Id", session.SalleId);
            return View(session);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,duree,dateDebut,SalleId,FormateurId,FormationId")] Session session)
        {
            if (id != session.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormateurId"] = new SelectList(_context.Formateurs, "Id", "Id", session.FormateurId);
            ViewData["FormationId"] = new SelectList(_context.Formations, "Id", "Id", session.FormationId);
            ViewData["SalleId"] = new SelectList(_context.Salles, "Id", "Id", session.SalleId);
            return View(session);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .Include(s => s.Formateur)
                .Include(s => s.Formation)
                .Include(s => s.Salle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.Id == id);
        }
        
        public async Task<IActionResult> ParticipantsForSession(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .Include(s => s.Participants)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }


        public async Task<IActionResult> AddParticipant(int id)
        {
            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            // Fetch all participants from the database
            var participants = await _context.Participants.ToListAsync();

            // Pass the session ID and list of participants to the view
            ViewBag.SessionId = id;
            ViewBag.Participants = participants;

            return View(session);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddParticipant(int sessionId, int participantId)
        {
            var session = await _context.Sessions.Include(s => s.Participants).FirstOrDefaultAsync(s => s.Id == sessionId);
            var participant = await _context.Participants.FindAsync(participantId);

            if (session == null || participant == null)
            {
                return NotFound();
            }

            // Add the participant to the session's participants
            session.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
